    public class GetParamsService
    {
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IParamRepository _paramRepository;
        public GetParamsService(IMemoryCache memoryCache,
            IParamRepository paramRepository)
        {
            _cache = memoryCache;
            _cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(2));
            _paramRepository = paramRepository;
        }
        public async Task<(int id, string name)> GetParams<TEntity>(string code) where TEntity : class
        {
            string cacheIdKey = CacheKeys.GetIdKey<TEntity>();
            string cacheNameKey = CacheKeys.GetNameKey<TEntity>();
            if (!_cache.TryGetValue(cacheIdKey, out int cacheId)
                | !_cache.TryGetValue(cacheNameKey, out string cacheName))
            {
                var param = await _paramRepository.GetParamsByCode<TEntity>(code);
                cacheId = param.id;
                cacheName = param.name;
                _cache.Set(cacheIdKey, cacheId, _cacheOptions);
                _cache.Set(cacheNameKey, cacheName, _cacheOptions);
            }
            return (cacheId, cacheName);
        }
    }
