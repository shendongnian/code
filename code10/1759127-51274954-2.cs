    public async Task<T> GetAsync<T>(string key) where T : class {
        var serializedObject = await _cache.GetStringAsync(key);
        if (serializedObject == null) {
            return Task.FromResult<T>(null);
        }
        return JsonConvert.DeserializeObject<T>(serializedObject);
    }
