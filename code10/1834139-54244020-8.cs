    public static class WebApiConfig {
    
        public static void Register(HttpConfiguration config) {
    
            // Other stuff...
        
            var jsonFormatter = new MyJsonFormatter();
            config.Formatters.Clear();
            config.Formatters.Insert(0, jsonFormatter);
    
            //...
        }
    }
