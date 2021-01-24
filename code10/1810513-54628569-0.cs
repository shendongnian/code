    public class SomeMiddleware
    {
        private readonly RequestDelegate _next;
        public SomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                var claims = new List<Claim>
                {
                    new Claim("SomeClaim", "SomeValue")
                };
                var appIdentity = new ClaimsIdentity(claims);
                httpContext.User.AddIdentity(appIdentity);
                await _next(httpContext);
            }
        }
    }
