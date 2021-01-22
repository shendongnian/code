    internal static class DictionaryExtensions
    {
        public static Dictionary<T1, T2> Merge<T1, T2>(this Dictionary<T1, T2> first, Dictionary<T1, T2> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            var merged = new Dictionary<T1, T2>();
            first.ToList().ForEach(kv => merged[kv.Key] = kv.Value);
            second.ToList().ForEach(kv => merged[kv.Key] = kv.Value);
            return merged;
        }
    }
