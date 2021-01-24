    public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IProvideCacheKey, IRequest<TResponse>
    {
        private readonly IMemoryCache _cache;
        public CacheBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Check in cache if we already have what we're looking for
            var cacheKey = request.CacheKey;
            if (_cache.TryGetValue<TResponse>(cacheKey, out var cachedResponse))
            {
                return cachedResponse;
            }
            // If we don't, execute the rest of the pipeline, and add the result to the cache
            var response = await next();
            _cache.Set(cacheKey, response);
            return response;
        }
    }
