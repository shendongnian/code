    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.RouteExistingFiles = true;
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.IgnoreRoute("Content/{*pathInfo}");
        routes.IgnoreRoute("Scripts/{*pathInfo}");
        routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
        // webforms page route
        routes.MapPageRoute("home", "WebForm", "~/WebForm.aspx", false,
            new RouteValueDictionary {
            { "path", "page-not-found" },{ "pagename", "page-not-found" }
        });
        // default MVC route
        routes.MapRoute(
           "Default", // Route name
           "{controller}/{action}/{id}", // URL with parameters
           new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
    }
