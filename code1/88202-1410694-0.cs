    class A {
        public bool HasValue { get; private set; }
        public object Value { get; private set; }
        public void SetValue(bool hasValue, object value) {
            if (!hasValue && value != null)
                throw new ArgumentException();
            this.HasValue = hasValue;
            this.Value    = value;
        }
    }
