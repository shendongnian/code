    public class Cache : ICache
    {
        private readonly ConcurrentDictionary<string, object> _cache 
            = new ConcurrentDictionary<string, object>();
        public T Get<T>(string key)
        {
            object cached;
            if(_cache.TryGetValue(key, out cached) && cached is T)
            {
                return(T) cached;
            }
            return default(T);
        }
        public void Set(string key, object value)
        {
            _cache.AddOrUpdate(key, value, (s, o) => value);
        }
    }
