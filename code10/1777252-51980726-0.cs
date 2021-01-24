    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Add the following line before any route definitions
            routes.MapMvcAttributeRoutes();
            
            ... // add routes.MapRoute(...) definitions as required
        }
    }
