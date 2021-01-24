    public static IEnumerable<V> GetValues<K, V>(this IDictionary<K, V> dict, IEnumerable<K> keys)
    {
        foreach (var key in keys)
        {
            if (dict.TryGetValue(key, out V value))
            {
                yield return value;
            }
        }            
    }
