    public static void AddValue<TKey, TValue>
        (this IDictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
    {
        List<TValue> values;
        if (!dictionary.TryGetValue(key, out values))
        {
            values = new List<TValue>();
            dictionary.Add(key, values);
        }
        values.Add(value);
    }
