    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            //Required for the route prefix attributes to work!
            routes.MapMvcAttributeRoutes();
    
            routes.MapRoute(
                "ProfileUrlIndexActionRemoval",
                "Profile/{id}",
                new { controller = "Profile", action = "Index" }
            );
    
            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
    
            routes.MapRoute(
                name: "About",
                url: "About/{action}/{id}",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
            );
    
            routes.MapRoute(
                name: "Contact",
                url: "Contact/{action}/{id}",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );
    
            routes.MapRoute(
                "Default_Frieldly",
                "{*id}",
                new { controller = "Profile", action = "Index" }
            );
        }
    }
