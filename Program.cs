using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add logging and other services as needed
builder.Services.AddLogging();

var app = builder.Build();

// Register the correlation id middleware
app.UseMiddleware<CorrelationIDMiddleware>();

// A simple test endpoint
app.MapGet("/", (Microsoft.AspNetCore.Http.HttpContext ctx) =>
{
    return Results.Ok(new { Message = "Hello from BookManagementAPI", CorrelationId = ctx.Response.Headers["X-Correlation-Id"].ToString() });
});

app.Run();
