    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // ...
            var formatters = GlobalConfiguration.Configuration.Formatters;
            
            // Remove the xmlformatter
            formatters.Remove(formatters.XmlFormatter);
            // Ignore reference loops
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // Use snake_case
            formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
                {
                    ProcessDictionaryKeys = true // <--- Use SnakeCaseNamingStrategy for Dictionaries (So HttpError's)
                }
            };
        }
    }
