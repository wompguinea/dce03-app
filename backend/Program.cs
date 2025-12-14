var builder = WebApplication.CreateBuilder(args);

// Add CORS support
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

app.MapGet("/todos", () =>
{
    var todos = new[]
    {
        new { id = 1, title = "Learn AWS", completed = false },
        new { id = 2, title = "Build backend API", completed = true },
        new { id = 3, title = "Create frontend", completed = true },
        new { id = 4, title = "Deploy to AWS", completed = false }
    };

    return Results.Json(todos);
});

app.Run();
