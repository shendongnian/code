        public static T MergeLeft<T, K, V>(this T me, params Dictionary<K, V>[] others)
            where T : Dictionary<K, V>, new()
        {
            return me.MergeLeft(me.Comparer, others);
        }
        public static T MergeLeft<T, K, V>(this T me, IEqualityComparer<K> comparer, params Dictionary<K, V>[] others)
            where T : Dictionary<K, V>, new()
        {
            T newMap = Activator.CreateInstance(typeof(T), new object[] { comparer }) as T;
            foreach (Dictionary<K, V> src in 
                (new List<Dictionary<K, V>> { me }).Concat(others))
            {
                // ^-- echk. Not quite there type-system.
                foreach (KeyValuePair<K, V> p in src)
                {
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }
