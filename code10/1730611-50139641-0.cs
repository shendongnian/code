    public class MyAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
    
        public MyAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/endpoint")
                && !context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
    
            await _next.Invoke(context);
        }
    }
