    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
    
            // Convention-based routing.
            
           //...code removed for brevity
        }
    }
