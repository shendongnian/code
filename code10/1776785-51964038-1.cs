    using System.Web.Http;
    
    ...
    
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
    
        RegisterGlobalFilters(GlobalFilters.Filters);
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
