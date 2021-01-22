    protected void Application_Start(object sender, EventArgs e)
    {
        ConfigurationSuccessful();
    }
    public static bool ConfigurationSuccessful()
    {
        var container = StructureMapRegistry.Initialize();
        GlobalConfiguration.Configuration.DependencyResolver = new StructureMapResolver(container);
        AreaRegistration.RegisterAllAreas();
        GlobalConfiguration.Configure(WebApiConfig.Register);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        return true;
    }
