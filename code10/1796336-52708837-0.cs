    /// <summary>
    /// Static class that manages cached IFlurlClient instances
    /// </summary>
    public static class FlurlClientManager
    {
        /// <summary>
        /// Cache for the clients
        /// </summary>
        private static readonly ConcurrentDictionary<string, IFlurlClient> Clients =
            new ConcurrentDictionary<string, IFlurlClient>();
        /// <summary>
        /// Gets a cached client for the host associated to the input URL
        /// </summary>
        /// <param name="url"><see cref="Url"/> or <see cref="string"/></param>
        /// <returns>A cached <see cref="FlurlClient"/> instance for the host</returns>
        public static IFlurlClient GetClient(Url url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            return PerHostClientFromCache(url);
        }
        /// <summary>
        /// Gets a cached client with a proxy attached to it
        /// </summary>
        /// <returns>A cached <see cref="FlurlClient"/> instance with a proxy</returns>
        public static IFlurlClient GetProxiedClient()
        {
            string proxyUrl = ChooseProxy();
            return ProxiedClientFromCache(proxyUrl);
        }
        private static string ChooseProxy()
        {
            // Do something and return a proxy URL
            return "http://myproxy";
        }
        private static IFlurlClient PerHostClientFromCache(Url url)
        {
            return Clients.AddOrUpdate(
                key: url.ToUri().Host,
                addValueFactory: u => {
                    return CreateClient();
                },
                updateValueFactory: (u, client) => {
                    return client.IsDisposed ? CreateClient() : client;
                }
            );
        }
        private static IFlurlClient ProxiedClientFromCache(string proxyUrl)
        {
            return Clients.AddOrUpdate(
                key: proxyUrl,
                addValueFactory: u => {
                    return CreateProxiedClient(proxyUrl);
                },
                updateValueFactory: (u, client) => {
                    return client.IsDisposed ? CreateProxiedClient(proxyUrl) : client;
                }
            );
        }
        private static IFlurlClient CreateProxiedClient(string proxyUrl)
        {
            HttpMessageHandler handler = new SocketsHttpHandler()
            {
                Proxy = new WebProxy(proxyUrl),
                UseProxy = true,
                PooledConnectionLifetime = TimeSpan.FromMinutes(10)
            };
            HttpClient client = new HttpClient(handler);
            return new FlurlClient(client);
        }
        private static IFlurlClient CreateClient()
        {
            HttpMessageHandler handler = new SocketsHttpHandler()
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10)
            };
            HttpClient client = new HttpClient(handler);
            return new FlurlClient(client);
        }
    }
