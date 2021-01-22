    public static class DictionaryExtensions
    {
        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dic, 
            Func<TValue, bool> predicate)
        {
            var keys = (from d in dic where predicate(d.Value) select d.Key).ToList();
            foreach (var key in keys)
            {
                dic.Remove(key);
            }
        }
    }
    ...
    dictionary.RemoveAll(x => x.Member == foo);
