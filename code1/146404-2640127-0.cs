    routes.MapRoute(
        "Default2", // Route name
        "TestArea/{controller}/{action}/{id}", // URL with parameters
        new { controller = "Hello", action = "Index",area="TestArea",  id = UrlParameter.Optional } // Parameter defaults
    );
    
    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
    );
