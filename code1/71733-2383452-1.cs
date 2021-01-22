    protected void Application_Start()
    {
    
       //This is where you register your concrete types with StructureMap
        Bootstrapper.ConfigureStructureMap();
    
        //Our very own Controller Factory
        ControllerBuilder.Current.SetControllerFactory
        (new StructureMapControllerFactory());
    
        RegisterRoutes(RouteTable.Routes);
    }
