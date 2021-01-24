    protected void Application_Start()
        {
            ModelValidatorProviders.Providers.Add(new CustomMetadataValidationProvider());
    
            AreaRegistration.RegisterAllAreas();
    
            RegisterRoutes(RouteTable.Routes);
        }
