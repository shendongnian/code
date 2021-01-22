        public static void RemoveAll<TKey, TValue>(this IDictionary<TKey, TValue> dic, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            foreach (var kvp in dic.Where(predicate))
            {
                dic.Remove(kvp.Key);
            }
        }
    dictionary.RemoveAll( kvp => kvp.Value.Member == foo);
