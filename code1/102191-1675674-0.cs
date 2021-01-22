    protected void Application_Start(object sender, EventArgs e)
    {
        //do stuff
        RegisterRoutes(RouteTable.Routes);
        //do stuff
    ?
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.RouteExistingFiles = true;
            routes.Add(new Route("{controller}/{action}",
               new RouteValueDictionary { { "controller", "user" }, { "action", "home" } },
               new RouteValueDictionary { { "controller", @"^(?!Resources)\w*$" }, { "action", "[a-zA-Z]+" } },// means that .htm path will go straight to the file, not thru our router
               new MvcRouteHandler()));
    }
