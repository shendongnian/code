namespace MyApp.Framework.Logging
    {
        public class W3CLayout : PatternLayout
        {
            public override string Header
            {
                get { return buildW3CLogHeader(); }
                set {  }
            }
            private string buildW3CLogHeader()
            {
                var header = new StringBuilder();
                header.AppendLine("#Software: " + ConfigurationSettings.ProductName + " " + ConfigurationSettings.Product + " " + ConfigurationSettings.Version);
                header.AppendLine("#Version: 1.0 // Reference: http://www.w3.org/TR/WD-logfile");
                header.AppendLine("#Date: " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                header.AppendLine("#Fields: date time cs-host cs-method cs-uri-stem cs-uri-query s-port cs-username c-ip cs(User-Agent) cs(Referer) sc-status time-taken");
                return header.ToString();
            }
        }
    }
On the class above, I called `ConfigurationSettings.ProductName` which initialize another instance of `log4net`. I have to be careful not calling any `private static ILog _log = LogManager.GetLogger<ClassName>();` anywhere when using inherited class.
