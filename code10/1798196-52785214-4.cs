        public static void RegisterRoutes(RouteCollection routes)
        {
            foreach (var route in Extensions.GetRoutes())
            {
                routes.Add(route);
            }
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
