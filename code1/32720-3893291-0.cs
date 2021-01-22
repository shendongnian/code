        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            //TODO All arg checks
            HashSet<TKey> keys = new HashSet<TKey>();
            foreach (T item in source)
            {
                TKey key = keySelector(item);
                if (!keys.Contains(key))
                {
                    keys.Add(key);
                    yield return item;
                }
            }
        }
