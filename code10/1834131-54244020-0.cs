    public static class WebApiConfig {
    
        public static void Register(HttpConfiguration config) {
    
            // Other stuff...
        
            config.Formatters.Clear();
            config.Formatters.Insert(0, new MyJsonFormatter());          
    
            //...
        }
    }
