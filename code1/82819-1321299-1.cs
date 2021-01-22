    public class ReportType
    {
      public static ReportType CreateDefaults()
      {
        return new ReportType
        {
           DisplayName =  ConfigurationManager.AppSettings["DefaultDisplayName"],
           ReportName = ConfigurationManager.AppSettings["DefaultReportName"]
        };
      }
    }
