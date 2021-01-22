    class Foo {
        public string Value { get; set; }
        public Type TheType { get; set; }
        public T CastValue<T>() {
             return (T)Convert.ChangeType(Value, typeof(T));
        }
    }
