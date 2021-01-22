    static class OrderedDictionaryExtensions {
        public static void Add(
            this OrderedDictionary dictionary,
            string key,
            string value,
            Predicate<string> predicate
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
