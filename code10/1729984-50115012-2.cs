    public class ExpiredCollection
    {
        private readonly MemoryCache _cache;
        private readonly int _hoursLimit;
        public ExpiredCollection(int hoursLimit)
        {
            _cache = new MemoryCache("sample");
            _hoursLimit = hoursLimit;
        }
        public void Add<T>(T value)
        {
            var item = CreateCacheItem(value);
            var policy = CreateItemPolicy();
            _cache.Add(item, policy);
        }
        private CacheItem CreateCacheItem<T>(T value)
        {
            var addedValue = new SavedItem<T>
            {
                Timestamp = DateTime.Now,
                Value = value
            };
            // Create unique key to satisfy MemoryCache contract
            var uniqueKey = Guid.NewGuid().ToString();
            return new CacheItem(uniqueKey, addedValue);
        }
        private CacheItemPolicy CreateItemPolicy()
        {
            // This will set a time when item will be removed from the cache
            var expirationTime = DateTime.Now.AddSeconds(_hoursLimit);
            var offset = new DateTimeOffset(expirationTime);
            return new CacheItemPolicy
            {
                AbsoluteExpiration = offset
            };
        }
        public IEnumerable<T> GetLast<T>(int amount)
        {
            return _cache.Select(pair => (SavedItem<T>)pair.Value)
                         .OrderByDescending(item => item.Timestamp)
                         .Select(item => item.Value)
                         .Take(amount);
        }
    }
