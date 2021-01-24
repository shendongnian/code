    /// <summary>
    /// Provides instances of the System.Net.Http.HttpClient.
    /// </summary>
    public interface INetHttpClientFactory
    {
        /// <summary>
        /// <para>
        /// Returns a generic HttpClient, with no exotic options like client certificates or custom server certificate validation.
        /// </para>
        /// <para>
        /// Returns a client that is valid for at least two minutes. Behavior is undefined if it is used beyond that time.
        /// </para>
        /// </summary>
        HttpClient CreateClient();
    }
    /// <summary>
    /// <para>
    /// Caches HttpClients or their handlers by purpose, as resource-efficiently as possible, while still allowing fairly easy customization, such as client certificates or server certificate validation.
    /// </para>
    /// </summary>
    public interface IPurposeCachedHttpClientFactory : INetHttpClientFactory
    {
        HttpClient CreateClient(HttpClientPurpose purpose);
        HttpMessageHandler CreateHandler(HttpClientPurpose purpose);
    }
    public class PurposeCachedHttpClientFactory : IPurposeCachedHttpClientFactory
    {
        private static IMemoryCache CachedClients { get; } = new MemoryCache(new MemoryCacheOptions());
        private static IMemoryCache ExpiredClients { get; } = new MemoryCache(new MemoryCacheOptions());
        private static readonly TimeSpan ClientLifetime = TimeSpan.FromSeconds(240); // Match the time TCP connections are kept open, for symmetry if nothing else (must not be less than two minutes for reasonable use)
        /// <summary>
        /// <para>
        /// Returns a generic HttpClient, with no exotic options like client certificates or custom server certificate validation.
        /// </para>
        /// <para>
        /// Returns a cached client that is valid for at least two minutes. Behavior is undefined if it is used beyond that time.
        /// </para>
        /// </summary>
        public HttpClient CreateClient()
        {
            return this.CreateClient(HttpClientPurpose.GenericPurpose);
        }
        /// <summary>
        /// <para>
        /// Returns a customized HttpClient, whose message handler is determined by its purpose.
        /// </para>
        /// <para>
        /// Returns a cached client that is valid for at least two minutes. Behavior is undefined if it is used beyond that time.
        /// </para>
        /// </summary>
        public HttpClient CreateClient(HttpClientPurpose purpose)
        {
            var messageHandler = this.CreateHandler(purpose);
            return new HttpClient(messageHandler, disposeHandler: false); // Essential to NOT dispose the handler when disposing the client
        }
        /// <summary>
        /// <para>
        /// Returns a cached HttpMessageHandler determined by the purpose.
        /// </para>
        /// <para>
        /// It is recommended to use the CreateClient() method, unless direct access to the handler is needed.
        /// </para>
        /// <para>
        /// Returns a cached handler that is valid for at least two minutes. Behavior is undefined if it is used beyond that time.
        /// </para>
        /// </summary>
        public HttpMessageHandler CreateHandler(HttpClientPurpose purpose)
        {
            var messageHandler = this.CreateMessageHandler(purpose.UniqueName, purpose.MessageHandlerFactory);
            return messageHandler;
        }
        private HttpMessageHandler CreateMessageHandler(string uniqueName, Func<HttpMessageHandler> messageHandlerFactory)
        {
            // Try to use a cached instance
            return CachedClients.GetOrCreate(key: uniqueName, factory: cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = ClientLifetime;
                cacheEntry.RegisterPostEvictionCallback(DidEvictActiveClient);
                return messageHandlerFactory();
            });
        }
        /// <summary>
        /// Schedules expired clients to be disposed (via the cache of expired items) after they are evicted from the cache of active clients.
        /// </summary>
        private static void DidEvictActiveClient(object key, object value, EvictionReason reason, object state)
        {
            // Schedule it to be disposed
            ExpiredClients.GetOrCreate(key: value, factory: cacheEntry =>
            {
                cacheEntry.Priority = CacheItemPriority.NeverRemove;
                // Eventually dispose it
                cacheEntry.AbsoluteExpirationRelativeToNow = ClientLifetime;
                cacheEntry.RegisterPostEvictionCallback(DidEvictExpiredClient);
                System.Diagnostics.Debug.Assert(cacheEntry.Key != null);
                return cacheEntry.Key;
            });
        }
        /// <summary>
        /// Disposes expired clients after they are evicted from the cache of expired items (i.e. after a delay).
        /// </summary>
        private static void DidEvictExpiredClient(object key, object value, EvictionReason reason, object state)
        {
            // TODO: Put this in a try/catch after confirming that it works without exceptions for some time
            ((HttpMessageHandler)value).Dispose();
        }
    }
