    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "Default",                                              // Route name
            "{controller}/{action}/{id}",                           // URL with parameters
            new { controller = "home", action = "index", id = "" },
            new { controller = new LowercaseConstraint(), action = new LowercaseConstraint() }
        );
    }
