    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapAttributeRoutes(config =>
        {
            config.AddRoutesFromController<ControllerName>();
        });
    }
