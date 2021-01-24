    public class MvcApplication : System.Web.HttpApplication
    {
      private ILocalWebServerReportingService reportingService;
      protected void Application_Start()
      {
        ...
        reportingService = FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        ...
      }
      protected void Application_End()
      {
        reportingService.KillAsync().GetAwaiter().GetResult();
      }
    }
