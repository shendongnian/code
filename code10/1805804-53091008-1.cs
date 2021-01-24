    public class RedisCache : IRedisCache {
    
        public Task<T> GetValue<T>(string code) {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            var value = cache.StringGet($"Device_Status:{code}");        
            T resultFromCache = JsonConvert.DeserializeObject<T>(value);
            return Task.FromResult(resultFromCache);
        }
    }
