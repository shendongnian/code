    public async Task<T> GetValueAsync<T>(string key)
    {
      if (_cache.ContainsKey(key))
      {
        return _cache.GetItem(key);
      }
      T result = await _api.GetValueAysnc(key);
      _cache.Add(key, result);
      return result;
    }
