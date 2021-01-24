    public Task<T> GetValueAsync<T>(string key)
    {
      if (_cache.TryGet(key, out Task<T> result))
      {
        return result;
      }
      return GetAndCacheValueAsync(string key);
    }
    private async Task<T> GetAndCacheValueAsync<T>(string key)
    {
      var task = _api.GetValueAysnc(key);
      result = await task;
      _cache.Add(key, task);
      return result;
    }
