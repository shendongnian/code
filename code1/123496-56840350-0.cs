        /// <summary>
        /// Creates a filtered copy of this dictionary, using the given predicate.
        /// </summary>
        public static Dictionary<K, V> Filter<K, V>(this Dictionary<K, V> dict,
                Predicate<KeyValuePair<K, V>> pred) {
            return dict.Where(it => pred(it)).ToDictionary(it => it.Key, it => it.Value);
        }
