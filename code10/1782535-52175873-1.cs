        public class AuthenticationMiddleware
        {
        private readonly RequestDelegate _next;
        private readonly Settings _settings;
        public AuthenticationMiddleware(RequestDelegate next, IOptions<Settings> options)
        {
            _next = next;
            _settings = options.Value;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //await context.Response.WriteAsync($"This is { GetType().Name }");
            //decide whether to invoke line below based on your business logic
            await _next(context);
        }
        }
