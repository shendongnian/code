    static class OrderedDictionaryExtensions {
        public static void Add<TKey, TValue>(
            this OrderedDictionary dictionary,
            TKey key,
            TValue value,
            Predicate<TKey> predicate
        ) {
            if (dictionary == null) {
                throw new ArgumentNullException("dictionary");
            }
            if (predicate == null) {
                throw new ArgumentNullException("predicate");
            }
            if (predicate(key)) {
                dictionary.Add(key, value);
            }
        }
    }
