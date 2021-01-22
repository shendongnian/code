    static class Extensions {
        public static void AddToNestedDictionary<TKey, TNestedKey, TNestedValue>(
            this IDictionary<TKey, Dictionary<TNestedKey, TNestedValue>> dictionary,
            TKey key,
            TNestedKey nestedKey,
            TNestedValue nestedValue
        ) {
            if(dictionary == null) {
                throw new ArgumentNullException("dictionary");
            }
            if(key == null) {
                throw new ArgumentNullException("key");
            }
            if(nestedKey == null) {
                throw new ArgumentNullException("nestedKey");
            }
            Dictionary<TNestedKey, TNestedValue> nested;
            if (!dictionary.TryGetValue(key, out nested)) {
                nested = new Dictionary<TNestedKey, TNestedValue>();
                dictionary.Add(key, nested);
            }
            nested.Add(nestedKey, nestedValue);
        }
    }
