using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services before building the application
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add controller services
builder.Services.AddControllers();


var app = builder.Build();

// Use HTTPS redirection middleware
app.UseHttpsRedirection();

// Use Authorization (if you have any authorization setup)
app.UseAuthorization();

// Map controllers to route HTTP requests
app.MapControllers();

// Start the app
app.Run();
