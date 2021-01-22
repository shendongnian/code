    class DictionaryComparer<TKey, TValue> : IEqualityComparer<Dictionary<TKey, TValue>> {    
        public bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y) {
            if (x == null) {
                throw new ArgumentNullException("x");
            }
            if (y == null) {
                throw new ArgumentNullException("y");
            }
            if (x.Count != y.Count) {
                return false;
            }           
            foreach (var kvp in x) {
                TValue value;
                if(!x.TryGetValue(kvp.Key, out value)) {
                    return false;
                }
                if(!kvp.Value.Equals(value)) {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(Dictionary<TKey, TValue> obj) {
            if (obj == null) {
                throw new ArgumentNullException("obj");
            }
            int hash = 0;
            foreach (var kvp in obj) {
                hash = hash ^ kvp.Key.GetHashCode() ^ kvp.Value.GetHashCode();
            }
            return hash;
        }
    }
