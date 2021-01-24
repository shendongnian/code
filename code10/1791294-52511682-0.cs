    [Serializable]
    public struct KeyValuePair<TKey, TValue> {
        private TKey key;
        private TValue value;
 
        public KeyValuePair(TKey key, TValue value) {
            this.key = key;
            this.value = value;
        }
 
        public TKey Key {
            get { return key; }
        }
 
        public TValue Value {
            get { return value; }
        }
 
        public override string ToString() {
            StringBuilder s = StringBuilderCache.Acquire();
            s.Append('[');
            if( Key != null) {
                s.Append(Key.ToString());
            }
            s.Append(", ");
            if( Value != null) {
               s.Append(Value.ToString());
            }
            s.Append(']');
            return StringBuilderCache.GetStringAndRelease(s);
        }
    }
