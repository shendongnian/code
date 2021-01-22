        public static void MergeOverwrite<T1, T2>(this ConcurrentDictionary<T1, T2> dictionary, IDictionary<T1, T2> newElements)
        {
            if (newElements == null || newElements.Count == 0) return;
            foreach (var ne in newElements)
            {
                dictionary.AddOrUpdate(ne.Key, ne.Value, (key, value) => value);
            }
        }
