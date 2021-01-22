    public static IDictionary<TKey, TValue> Merge<TKey, TValue>(IEnumerable<IDictionary<TKey, TValue>> dictionaries)
    {
        // ...
    }
    public static IDictionary<TKey, TValue> Merge<TKey, TValue>(params IDictionary<TKey, TValue>[] dictionaries)
    {
        return Merge((IEnumerable<TKey, TValue>) dictionaries);
    }
