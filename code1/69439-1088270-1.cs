    public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> d, TKey key)
    {
        TValue v = default(TValue);
        d.TryGetValue(key, out v);
        return v;
    }
    public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> d, TKey key, Func<TValue> value)
    {
        TValue v = d.Get(key);
        if (v == null)
        {
            v = value();
            d.Add(key, v);
        }
        return v;
    }
