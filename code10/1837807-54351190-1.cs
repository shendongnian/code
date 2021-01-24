    public static class IDistributedCacheExtensions
    {
        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key) =>
            JsonConvert.DeserializeObject<T>(await cache.GetStringAsync(key));
        public static Task Set<T>(this IDistributedCache cache, string key, T value) =>
            cache.SetStringAsync(key, JsonConvert.SerializeObject(value));
    }
