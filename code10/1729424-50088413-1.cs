    proteced void Application_Start()
    {
    	AreaRegisteration.registerAllArea();
    	ViewEngines.Engines.Clear();
    	ViewEngines.Engines.Add(new CustomrazorViewEngine());
    	RoutConfig.registerRoutes(RouteTable.Routes);
    }
