    /// <summary>
    /// Helper class for connection with Redis Server.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Configuration option to connect with Redis.
        /// </summary>
        private static Lazy<ConfigurationOptions> configOptions(string ipAddress)
        {
            var configOptions = new ConfigurationOptions();
            configOptions.EndPoints.Add(ipAddress);
            /*
            ...Other Configurations...
            */
            return new Lazy<ConfigurationOptions>(() => configOptions);
        }
    
        private static Lazy<ConnectionMultiplexer> lazyConnection(string ipAddress)
        {
            return new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions(ipAddress).Value));
        }
    
        /// <summary>
        /// Connection property to connect Redis.
        /// </summary>
        public static ConnectionMultiplexer Connection(string ipAddress)
        {
            return lazyConnection(ipAddress).Value;
        }
    }
