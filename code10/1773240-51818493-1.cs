    public static class RouteConfig
    {
        public static IRouteBuilder Use(IRouteBuilder routeBuilder)
        {
            //eg sample for defining Custom route
            //routeBuilder.MapRoute("blog", "blog",
            //    defaults: new { controller = "Home", action = "Index" });
            routeBuilder.MapRoute(name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            return routeBuilder;
        }
    }
