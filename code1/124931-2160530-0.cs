    public static void AddValue<TKey, TValue>
        (this IDictionary<TKey, TValue> dict, 
              TKey key, 
              Func<TKey, TValue> getValue)
    {
        List<TValue> value;
        if (!dict.TryGetValue(key, out value))
        {
            value = getValue(key)
            dict.Add(key, values);
        }
        values.Add(value);
    }
