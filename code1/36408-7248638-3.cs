    /// <summary>
    /// Delegate type of the service method to perform.
    /// </summary>
    /// <param name="proxy">The service proxy.</param>
    /// <typeparam name="T">The type of service to use.</typeparam>
    internal delegate void UseServiceDelegate<in T>(T proxy);
    /// <summary>
    /// Wraps using a WCF service.
    /// </summary>
    /// <typeparam name="T">The type of service to use.</typeparam>
    internal static class Service<T>
    {
        /// <summary>
        /// A dictionary to hold looked-up endpoint names.
        /// </summary>
        private static readonly IDictionary<Type, string> cachedEndpointNames = new Dictionary<Type, string>();
        /// <summary>
        /// A dictionary to hold created channel factories.
        /// </summary>
        private static readonly IDictionary<string, ChannelFactory<T>> cachedFactories =
            new Dictionary<string, ChannelFactory<T>>();
        /// <summary>
        /// Uses the specified code block.
        /// </summary>
        /// <param name="codeBlock">The code block.</param>
        internal static void Use(UseServiceDelegate<T> codeBlock)
        {
            var factory = GetChannelFactory();
            var proxy = (IClientChannel)factory.CreateChannel();
            var success = false;
            try
            {
                using (proxy)
                {
                    codeBlock((T)proxy);
                }
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }
        /// <summary>
        /// Gets the channel factory.
        /// </summary>
        /// <returns>The channel factory.</returns>
        private static ChannelFactory<T> GetChannelFactory()
        {
            lock (cachedFactories)
            {
                var endpointName = GetEndpointName();
                if (cachedFactories.ContainsKey(endpointName))
                {
                    return cachedFactories[endpointName];
                }
                var factory = new ChannelFactory<T>(endpointName);
                cachedFactories.Add(endpointName, factory);
                return factory;
            }
        }
        /// <summary>
        /// Gets the name of the endpoint.
        /// </summary>
        /// <returns>The name of the endpoint.</returns>
        private static string GetEndpointName()
        {
            var type = typeof(T);
            var fullName = type.FullName;
            lock (cachedFactories)
            {
                if (cachedEndpointNames.ContainsKey(type))
                {
                    return cachedEndpointNames[type];
                }
                var serviceModel = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).SectionGroups["system.serviceModel"] as ServiceModelSectionGroup;
                if ((serviceModel != null) && !string.IsNullOrEmpty(fullName))
                {
                    foreach (var endpointName in serviceModel.Client.Endpoints.Cast<ChannelEndpointElement>().Where(endpoint => fullName.EndsWith(endpoint.Contract)).Select(endpoint => endpoint.Name))
                    {
                        cachedEndpointNames.Add(type, endpointName);
                        return endpointName;
                    }
                }
            }
            throw new InvalidOperationException("Could not find endpoint element for type '" + fullName + "' in the ServiceModel client configuration section. This might be because no configuration file was found for your application, or because no endpoint element matching this name could be found in the client element.");
        }
    }
