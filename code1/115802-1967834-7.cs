    static class Extensions {
        public static void AddToNestedDictionary<TKey, TNestedDictionary, TNestedKey, TNestedValue>(
            this IDictionary<TKey, TNestedDictionary> dictionary,
            TKey key,
            TNestedKey nestedKey,
            TNestedValue nestedValue
        ) where TNestedDictionary : IDictionary<TNestedKey, TNestedValue> {
            dictionary.AddToNestedDictionary(
                key,
                nestedKey,
                nestedValue,
                () => (TNestedDictionary)(IDictionary<TNestedKey, TNestedValue>)
                    new Dictionary<TNestedKey, TNestedValue>());
        }
        public static void AddToNestedDictionary<TKey, TNestedDictionary, TNestedKey, TNestedValue>(
            this IDictionary<TKey, TNestedDictionary> dictionary,
            TKey key,
            TNestedKey nestedKey,
            TNestedValue nestedValue,
            Func<TNestedDictionary> provider
        ) where TNestedDictionary : IDictionary<TNestedKey, TNestedValue> {
            TNestedDictionary nested;
            if (key == null) {
                throw new ArgumentNullException("key");
            }
            if (!dictionary.TryGetValue(key, out nested)) {
                nested = provider();
                dictionary.Add(key, nested);
            }
            nested.Add(nestedKey, nestedValue);
        }
    }
