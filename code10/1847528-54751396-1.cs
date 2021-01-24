    public async Task<T> GetValueAsync<T>(string key)
    {
      if (_cache.TryGet(key, out T result))
      {
        return result;
      }
      result = await _api.GetValueAysnc(key);
      _cache.Add(key, result);
      return result;
    }
