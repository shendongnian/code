    public class RouteCustom : IRouteCustom
    {
        private readonly IRouter _innerRouter;
    
        public RouteCustom(IRouter innerRouter)
        {
            _innerRouter = innerRouter ?? throw new ArgumentNullException(nameof(innerRouter));
        }
    
        public async Task RouteAsync(RouteContext context)
        {
            var serviceConfig = context.HttpContext.RequestServices.GetRequiredService<IServiceConfig>();
            // ...
        }
    
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            var serviceConfig = context.HttpContext.RequestServices.GetRequiredService<IServiceConfig>();
            // ...
        }
    }
