    static class OrderedDictionaryExtensions {
        public static bool Add(
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
                return true;
            }
            return false;
        }
    }
