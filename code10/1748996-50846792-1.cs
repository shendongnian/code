    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapRoute(
            name: "UserIdRoute",
            url: "{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
    public ActionResult Index(string id)
    {
        //Get users profile from the database using the id
        var viewModel = _userProfileService.Get(id);
        return View();
    }
