        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.Converters.Add(new StringDictionaryConverter());
        }
