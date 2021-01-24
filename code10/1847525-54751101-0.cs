    public Task<T> GetValue<T>(string key)
    {
        // Prefer a TryGet pattern if you can, to halve the number of lookups
        if (_cache.containsKey(key))
        {
            return _cache.GetItem(key);
        }
        var task = _api.GetValue(key);
        _cache.Add(key, task);
        return task;
    }
