    using System.Collections.Generic;
    namespace MyNamespace {
        public static class DictionaryExtensions {
            public static V GetValue<K, V>(this IDictionary<K, V> dict, K key) {
                return dict.GetValue(key, default(V));
            }
            public static V GetValue<K, V>(this IDictionary<K, V> dict, K key, V defaultValue) {
                V value;
                return dict.TryGetValue(key, out value) ? value : defaultValue;
            }
        }
    }
