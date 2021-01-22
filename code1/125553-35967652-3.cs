    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
     
        routes.MapMvcAttributeRoutes();
        routes.MapRoute(
           name: "Home",
           url: "{controller}/{action}",
           defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
