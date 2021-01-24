    public static class HelloWorldMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloWorldMiddleware>();
        }
    }
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate _next;
        public HelloWorldMiddleware(RequestDelegate next)
        {
            _next = next;
        }
 
        public async Task Invoke(HttpContext context, IOptionsSnapshopt<AppSettings> options)
        {
            await context.Response.WriteAsync($"PropA: {options.Value.PropA}");
        }
    }
    public class AppSettings
    {
        public string PropA { get; set; }
    }
