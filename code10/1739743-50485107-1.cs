    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
                All other config goes here
            */
            //This line registers the handler
            config.MessageHandlers.Add(new CustomTokenCheckMessageHandler());
        }
    }
