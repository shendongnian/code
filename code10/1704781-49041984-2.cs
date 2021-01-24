    public class InMemoryCache : ICache
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        public T Get<T>(string key)
        {
            var cached = _cache[key];
            return cached is T ? (T) cached : default(T);
        }
        public void Set(string key, object value)
        {
            _cache[key] = value;
        }
    }
