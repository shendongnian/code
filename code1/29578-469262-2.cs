    public static class DictionaryExtensions
    {
        public static void RemoveAll<TKey, TValue>(this IDictionary<TKey, TValue> dict, 
            Func<TValue, bool> predicate)
        {
            var keys = dict.Keys.Where(k => predicate(dict[k])).ToList();
            foreach (var key in keys)
            {
                dict.Remove(key);
            }
        }
    }
    ...
    dictionary.RemoveAll(x => x.Member == foo);
