    public static IDictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if(dictionary == null)
        {
            throw new ArgumentNullException("dictionary");
        }
        return dictionary.ToDictionary(pair => pair.Value, pair => pair.Key);
    }
