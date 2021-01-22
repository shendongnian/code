        public static void RegisterRoutes(RouteCollection routes)
        {
            ...
            // Special localisation route mapping - expects specific language/culture code as first param
            routes.MapRoute(
                name: "Localisation",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"[a-z]{2}|[a-z]{2}-[a-zA-Z]{2}" }
            );
            // Default routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
