    routes.MapRoute(
        "Home",
        "Home/{action}",
        new { controller = "Home", action = "index" }
    );
    routes.MapRoute(
        "Citysearch",
        "DynamicContent/{state}",
        new { controller = "Dashboard", action = "GetDynamicContent" }
    );
    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
