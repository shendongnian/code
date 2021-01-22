    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute("Pages3", "{url1}/{url2}/{url3}", MVC.Page.RedirectTo(), new { url1 = "", url2 = "", url3 = "" });
        routes.MapRoute("Pages2", "{url1}/{url2}", MVC.Page.RedirectTo(), new { url1 = "", url2 = "", url3 = "" });
        routes.MapRoute("Pages1", "{url1}", MVC.Page.RedirectTo(), new { url1 = "", url2 = "", url3 = "" });
    }
