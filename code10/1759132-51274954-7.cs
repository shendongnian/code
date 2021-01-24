    public async Task<T> GetAsync<T>(string key, Func<string,T> make) {
        var serializedObject = await _cache.GetStringAsync(key);
        if (serializedObject == null) {
            var res = make(key);
            _cache.PutStringAsync(key, JsonConvert.SerializeObject(res));
            return res;
        }
        return JsonConvert.DeserializeObject<T>(serializedObject);
    }
