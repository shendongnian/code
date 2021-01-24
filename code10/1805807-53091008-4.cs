    public async Task<T> GetValue(string code) {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        var value = await cache.StringGetAsync($"Device_Status:{code}");
        T resultFromCache = JsonConvert.DeserializeObject<T>(value);
        return resultFromCache;
    }
