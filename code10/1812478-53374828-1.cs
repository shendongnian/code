        public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{Category}",
            defaults: new { controller = "Product", action = "", Category = UrlParameter.Optional }
        );
    }
