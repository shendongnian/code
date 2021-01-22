    class Type0
    {
        public double Value { get; private set; }
        public Type0(double value)
        {
            Value = value;
        }
        public static implicit operator Int32(Type0 other)
        {
            return (Int32)other.Value;
        }
        public static implicit operator UInt32(Type0 other)
        {
            return (UInt32)Math.Abs(other.Value);
        }
    }
