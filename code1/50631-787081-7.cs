    public static TValue GetValueOrDefault<TKey, TValue>
        (this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        TValue value;
        dictionary.TryGetValue(key, out value);
        return value;
    }
    public static TValue GetValueOrDefault<TKey, TValue>
        (this IDictionary<TKey, TValue> dictionary, TKey key,
         TValue customDefault)
    {
        TValue value;
        if (dictionary.TryGetValue(key, out value))
        {
            return value;
        }
        else
        {
            return customDefault;
        }
    }
