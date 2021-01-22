    public struct VolatileBool
    {
        private volatile bool _value;
        public VolatileBool(bool value) => _value = value;
        public bool Value { get => _value; set => _value = value; }
    }
