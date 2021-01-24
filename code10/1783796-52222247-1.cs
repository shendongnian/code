     public class ItemDispatcher : ItemDispatcher
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache; // use interface of your implementation of redis cache
        private readonly int _cacheDuration;
        private readonly bool _isCacheEnabled;
        public EventDispatcher(IShowtimeUnitOfWork unitOfWork, IDistributedCache distCache)
        {
            _unitOfWork = unitOfWork;
           
            _distributedCache = distCache; // init cache in constructor
            _cacheDuration = _configuration.Get<int>("cache.duration"); // duration of your cache
            _isCacheEnabled = _configuration.Get<bool>("cache.isEnable"); // if the cache is enable or not
        }
         public async Task<ServiceResponse<ItemDto>> GetItemById(int id)
        {
          // Add this for each Task call
              var cacheKey = string.Empty;
                if (_isCacheEnabled)
                {
                    cacheKey = CacheUtils.GetCacheKey(CacheKeys.Event, id, (int)eventTab);
                    itemDto cacheResult = await _distributedCache.Get<ItemDto>(cacheKey);
                    if (cacheResult != null)
                        return new ServiceResponse<Item>(cacheResult);
                }
        }
