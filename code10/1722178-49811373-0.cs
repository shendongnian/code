    protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            List<SystemConfigurationModel> systemConfigurationValue = General.MapList<System_Configuration , SystemConfigurationModel> (_systemConfigurationService.GetAllSystemConfigData());
            Application["SystemConfig"] = new List<SystemConfigurationModel>(systemConfigurationValue);
        }
