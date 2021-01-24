    public static Dictionary<TKey, TValue> Add<TKey, TValue>(Dictionary<TKey, TValue> d1, Dictionary<TKey, TValue> d2) 
            where TValue : IComparable
        {
            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
        foreach (TKey key in d1.Keys) {
            if (d2.ContainsKey(key))
            {
                dynamic a = d1[key];
                dynamic b = d2[key];
                result[key] = a + b;
            }
            else
                result[key] = d1[key];
        }
        foreach (TKey key in d2.Keys) {
            if (!result.ContainsKey(key))
                result[key] = d2[key];
        }
        return result;
    }
