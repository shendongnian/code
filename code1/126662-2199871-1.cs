    public struct NullableDouble {
        public bool hasValue = false;
        private double _value;
        public double Value {
            get {
                if (hasValue)
                    return _value;
                else
                    throw new Exception(...);
            }
            set {
                hasValue = true;
                _value = value;
            }
        }
    }
