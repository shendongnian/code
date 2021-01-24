    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      
      var tempPath = Path.Combine(HttpRuntime.AppDomainAppPath, "jsreport");
      filters.Add(new JsReportFilterAttribute(new LocalReporting()
        .Configure(cfg =>
        {
          cfg.BaseUrlAsWorkingDirectory();
          cfg.TempDirectory = tempPath;
          return cfg;
        })
        .UseBinary(JsReportBinary.GetBinary())
        .AsUtility()
        .Create()));
    }
