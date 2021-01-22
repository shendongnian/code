    static class Extensions {
        public static void AddToNestedDictionary<TKey, TNestedKey, TNestedValue>(this Dictionary<TKey, Dictionary<TNestedKey, TNestedValue>> dictionary, TKey key, TNestedKey nestedKey, TNestedValue nestedValue) {
            Dictionary<TNestedKey, TNestedValue> nested;
            if (!dictionary.TryGetValue(key, out nested)) {
                nested = new Dictionary<TNestedKey, TNestedValue>();
                dictionary.Add(key, nested);
            }
            nested.Add(nestedKey, nestedValue);
        }
            
    }
