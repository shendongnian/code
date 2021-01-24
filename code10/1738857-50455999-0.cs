    public void Reload(IDictionary<TKey, TValue> values)
    {
        lock(_synclock)
        {
            _internalCache.Clear();
            _internalCache.AddRange(values);
        }
    }
