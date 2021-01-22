    class Foo<TValue> {
        public string Value { get; set; }
        public TValue TypedValue {
            get {
                return (TValue)Convert.ChangeType(Value, typeof(TValue));
            }
        }
    }
