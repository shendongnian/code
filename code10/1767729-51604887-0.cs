    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API routes
            config.MapHttpAttributeRoutes();
            // add to the front of the pipeline
            config.MessageHandlers.Insert(0, new HeartbeatMessagingHandler());
        }
    }
