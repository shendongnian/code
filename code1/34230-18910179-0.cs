    public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dict, K key)
    {
        return dict.GetValueOrDefault(key, default(V));
    }
    public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dict, K key, V defVal)
    {
        return dict.GetValueOrDefault(key, () => defVal);
    }
    public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dict, K key, Func<V> defValSelector)
    {
        V value;
        return dict.TryGetValue(key, out value) ? value : defValSelector();
    }
