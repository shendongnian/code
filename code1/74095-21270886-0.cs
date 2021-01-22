    public static class Extensions_MultiKeyDictionary {
        public static MultiKeyDictionary<K1, K2, V> ToMultiKeyDictionary<S, K1, K2, V>(this IEnumerable<S> items, Func<S, K1> key1, Func<S, K2> key2, Func<S, V> value) {
            var dict = new MultiKeyDictionary<K1, K2, V>(); 
            foreach (S i in items) { 
                dict.Add(key1(i), key2(i), value(i)); 
            } 
            return dict; 
        }
        public static MultiKeyDictionary<K1, K2, K3, V> ToMultiKeyDictionary<S, K1, K2, K3, V>(this IEnumerable<S> items, Func<S, K1> key1, Func<S, K2> key2, Func<S, K3> key3, Func<S, V> value) {
            var dict = new MultiKeyDictionary<K1, K2, K3, V>(); 
            foreach (S i in items) { 
                dict.Add(key1(i), key2(i), key3(i), value(i)); 
            } 
            return dict; 
        }
    }
