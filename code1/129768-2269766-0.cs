    class KeyedAutoCompleteStringCollection : AutoCompleteStringCollection {
    
        private readonly Dictionary<string,string> keyedValues =
            new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);
    
        public void Add(string value, string key) {
            base.Add(value);
            keyedValues.Add(value, key); // intentionally backwards
        }
    
        public string Lookup(string value) {
            string key;
            if (keyedValues.TryGetValue(value, out key)) {
                return key;
            }
            else {
                return null;
            }
        }
    
    }
