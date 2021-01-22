    static class SortedDictionaryExtensions {
        public static void MergeKeys<TKey1, TKey2, TValue>(
            this SortedDictionary<TKey1, SortedDictionary<TKey2, List<TValue>>> dictionary,
            TKey1 intoKey,
            TKey1 fromKey
        ) {
            if (dictionary == null) {
                throw new ArgumentNullException("dictionary");
            }
            if (intoKey == null) {
                throw new ArgumentNullException("intoKey");
            }
            if (fromKey == null) {
                throw new ArgumentNullException("fromKey");
            }
            SortedDictionary<TKey2, List<TValue>> to;
            SortedDictionary<TKey2, List<TValue>> from;
            if (!dictionary.TryGetValue(intoKey, out to)) {
                throw new ArgumentOutOfRangeException("intoKey");
            }
            if (!dictionary.TryGetValue(fromKey, out from)) {
                throw new ArgumentOutOfRangeException("fromKey");
            }
            foreach(TKey2 key in from.Keys) {
                if (to.Keys.Contains(key)) {
                    to[key].AddRange(from[key]);
                }
                else {
                    to.Add(key, from[key]);
                }
            }
            dictionary.Remove(fromKey);
        }
    }
