    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        GlobalConfiguration.Configure(WebAppConfig.Register);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
       
        // Your other existing code
    }
