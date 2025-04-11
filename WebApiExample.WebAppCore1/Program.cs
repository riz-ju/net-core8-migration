
using WebApiExample.Common.DataAccess;
using WebApiExample.DataStore;
using WebApiExample.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSystemWebAdapters();
builder.Services.AddHttpForwarder();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUnitOfWork,UserContext>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Get}/{id?}");
//app.MapControllers();

//app.MapForwarder("/{**catch-all}", app.Configuration["ProxyTo"]).Add(static builder => ((RouteEndpointBuilder)builder).Order = int.MaxValue);

app.Run();
