    public void Reload(IDictionary<TKey, TValue> values)
    {
        lock (_synclock)
        {
       	   _internalCache.Clear();
           foreach (var value in values)
              _internalCache.Add(value);
        }
    }
