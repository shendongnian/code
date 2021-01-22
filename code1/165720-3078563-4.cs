    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoutes();
        routes.MapRoute(
            "Default",
            "{controller}/{action}",
            new { controller = "Home", action = "Index" }
        );
    }
