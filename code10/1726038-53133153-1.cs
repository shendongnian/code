    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //this will ignore
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //this will serialize them to objects.
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
         }
    }
