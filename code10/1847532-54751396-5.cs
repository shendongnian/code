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
      result = await _api.GetValueAysnc(key);
      _cache.Add(key, Task.FromResult(result));
      return result;
    }
