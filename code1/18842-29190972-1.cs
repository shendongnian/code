    public static Dictionary<K, V> MergeLeft<K, V>(this Dictionary<K, V> me, params IDictionary<K, V>[] others)
        {
            var newMap = new Dictionary<K, V>(me, me.Comparer);
            foreach (IDictionary<K, V> src in
                (new List<IDictionary<K, V>> { me }).Concat(others))
            {
                // ^-- echk. Not quite there type-system.
                foreach (KeyValuePair<K, V> p in src)
                {
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }
