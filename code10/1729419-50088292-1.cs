    protected void Application_Start()
    {
    	AreaRegistration.RegisterAllAreas();
    	FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    	RouteConfig.RegisterRoutes(RouteTable.Routes);
    	BundleConfig.RegisterBundles(BundleTable.Bundles);
    
    	var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
    	razorEngine.ViewLocationFormats = new string[]
            {
                "~/Views/Home/Index.cshtml",
                "~/Views/Home/Index.vbhtml",
                "~/Views/Common/Index.cshtml",
                "~/Views/Common/Index.vbhtml"
            };
    }
