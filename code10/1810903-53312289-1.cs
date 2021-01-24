    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
    		var corsAttr = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(corsAttr);
    		
    		// Rest of config ...
        }
    }
