    class CacheResult<T> {
        public bool IsSuccess {get;}
        public T Value {get;}
        public CacheResult(T val, bool isSuccess) {
            Value = val;
            IsSuccess = isSuccess;
        }
    }
    public async Task<CacheResult<T>> GetAsync<T>(string key) {
        var serializedObject = await _cache.GetStringAsync(key);
        if (serializedObject == null) {
            return new CacheResult(default(T), false);
        }
        return new CacheResult(
            JsonConvert.DeserializeObject<T>(serializedObject)
        ,   true
        );
    }
