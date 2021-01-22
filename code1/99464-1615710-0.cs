    // Note the type parameters after the method name
    public static void AddIfNotPresent<TKey, TValue>
        (this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, value);
        }
    }
