    public static class DictionaryExt {
        public static Dictionary<TK, TV> Merge<TK, TV>(this Dictionary<TK, TV> src, Dictionary<TK, TV> add) {
            var merged = (src != null) ? new Dictionary<TK, TV>(src) : new Dictionary<TK, TV>();
            if (add != null)
                foreach (var kv in add)
                    if (merged.ContainsKey(kv.Key))
                        merged[kv.Key] = kv.Value;
                    else
                        merged.Add(kv.Key, kv.Value);
    
            return merged;
        }
    }
