    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
    		var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();
    		
    		// Rest of config ...
        }
    }
