    public interface ICache
    {
        void Add(string key, byte[] value, int expiration);
    }
    public class Cache : ICache
    {
        public IDistributedCache _cache;
        public Cache(IDistributedCache cache)
        {
            _cache = cache;
        }
        public void Add(string key, byte[] value, int expiration)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(expiration));
            _cache.Set(key, value, options);
        }
    }
