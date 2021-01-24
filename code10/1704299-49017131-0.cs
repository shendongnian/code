	public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.RouteExistingFiles = false;
        routes.IgnoreRoute("anotherproject/{*pathInfo}");
		
		// Register [Route] attributes
		routes.MapMvcAttributeRoutes();
        routes.MapPageRoute(
            "WebFormDefault",
            string.Empty,
            "~/index.aspx");
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }
