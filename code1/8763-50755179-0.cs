    public static class DictionaryExtension
    {
        public static void ForEach<T1, T2>(this Dictionary<T1, T2> dictionary, Action<T1, T2> action) {
            foreach(KeyValuePair<T1, T2> keyValue in dictionary) {
                action(keyValue.Key, keyValue.Value);
            }
        }
    }
