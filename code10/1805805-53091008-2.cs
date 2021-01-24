    public Task<T> GetValue(string code) {
        return Task.Run(() => {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            var value = cache.StringGet($"Device_Status:{code}");        
            T resultFromCache = JsonConvert.DeserializeObject<T>(value);
            return resultFromCache;
        });
    }
