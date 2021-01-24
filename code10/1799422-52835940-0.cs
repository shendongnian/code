    public static void Register(HttpConfiguration config)
    {
        //Web API routes
        config.MapHttpAttributeRoutes();
    
        //configure serializer
        config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
        config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
    	config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'";
    }
