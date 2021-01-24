    public static bool TryGetValue<TKey1, TKey2, TKey3, TValue>(this Dictionary<Tuple<TKey1, TKey2>, Dictionary<TKey3, TValue>> dict, TKey1 key1, TKey2 key2, TKey3 key3, out TValue value)
    {
        if (dict.TryGetValue(new Tuple<TKey1, TKey2>(key1, key2), out var subDict) && subDict.TryGetValue(key3, out value))
        {
            return true;
        }
        value = default(TValue);
        return false;
    }
    public static bool Add<TKey1, TKey2, TKey3, TValue>(this Dictionary<Tuple<TKey1, TKey2>, Dictionary<TKey3, TValue>> dict, TKey1 key1, TKey2 key2, TKey3 key3, TValue value)
    {
	var mainKey = new Tuple<TKey1, TKey2>(key1, key2);
        if (!dict.TryGetValue(mainKey, out var subDict))
        {
            subDict = new Dictionary<TKey3, TValue>();
            dict[mainKey] = subDict;
        }
	subDict.Add(key3, value);
    }
