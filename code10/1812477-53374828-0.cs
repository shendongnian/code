        public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{Category}",
            defaults: new { controller = "Product", action = "Index", Category = UrlParameter.Optional }
        );
    }
