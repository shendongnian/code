    public static boolean ativateSpecialDateSerialization = false;
    
    JsonConvert.DefaultSettings = () =>
    {
    	var settings = new JsonSerializerSettings();
    
    	if (ativateSpecialDateSerialization)
    	{
            // Special date parsing settings
    		settings.DateParseHandling = DateParseHandling.DateTime		
    	}
    	else
    	{
            // Default settings
    		settings.ContractResolver = new CamelCasePropertyNamesContractResolver(),
    		settings.Formatting = Formatting.None,
    		settings.Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter()},
    		settings.DateParseHandling = DateParseHandling.DateTimeOffset
    	}
    
    	return settings;
    };
    
    
    try
    {
    	ativateSpecialDateSerialization = true;
    	
    	// Call to your extrernal method
    }
    finally
    {
    	ativateSpecialDateSerialization = false;
    }
