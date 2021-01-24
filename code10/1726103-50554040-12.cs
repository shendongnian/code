    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Attribute routing
            routes.MapMvcAttributeRoutes();
            //Convention based routing
            //User route:
            routes.MapRoute(
                name: "UserRoot",
                url: "{shopName}/{action}", //eg MySite.com/UserShop
                defaults: new { controller = "Shop", action = "Index"}
            );
            //Catch-All InValid (NotFound) Routes
            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
        }
    }
    
