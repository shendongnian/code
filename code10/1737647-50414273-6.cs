    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
    
            // Web API routes
            config.MapHttpAttributeRoutes();
    
            config.Formatters.XmlFormatter.UseXmlSerializer = true; //HERE!
            ...
        }
