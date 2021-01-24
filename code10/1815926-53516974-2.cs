    public class DependencyResolverMiddleware
    {
        private readonly RequestDelegate _next;
    
        public DependencyResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task InvokeAsync(HttpContext httpContext)
        {
            DependencyResolver.Current.ResolverFunc = (type) =>
            {
                return httpContext.RequestServices.GetService(type);
            };
    
            await _next(httpContext);
        }
    }
