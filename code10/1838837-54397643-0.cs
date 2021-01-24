    /// <summary>
    /// Helper class for connection with Redis Server.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Configuration option to connect with Redis Database.
        /// </summary>
        private static Lazy<ConfigurationOptions> configOptions = new Lazy<ConfigurationOptions>(() =>
        {
            var configOptions = new ConfigurationOptions();
            configOptions.EndPoints.Add("Your Redis sever name");
            configOptions.AbortOnConnectFail = false;
            configOptions.AllowAdmin = true;
            configOptions.KeepAlive = 4;
            configOptions.Password = "Redis server password";
            return configOptions;
        });
    
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions.Value));
    
        /// <summary>
        /// Connection property to connect Redis Database.
        /// </summary>
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
