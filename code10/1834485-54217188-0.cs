    public static ILocalWebServerReportingService RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute()); 
      var rs = new LocalReporting()
        .Configure(cfg =>
        {
          cfg.BaseUrlAsWorkingDirectory();
          return cfg;
        })
        .UseBinary(JsReportBinary.GetBinary())
        .AsWebServer()
        .Create();
      rs.StartAsync().GetAwaiter().GetResult();
      filters.Add(new JsReportFilterAttribute(rs));
      return rs;
    }
