     public static class WebApiConfig
        {
            private static bool isRegistered;
            /// <summary>
            /// Registers the configuration.
            /// </summary>
            /// <param name="config">The Http Configuration.</param>
            public static void Register(HttpConfiguration config)
            {
                if (isRegistered)
                {
                    return;
                }
                config.MapHttpAttributeRoutes();
