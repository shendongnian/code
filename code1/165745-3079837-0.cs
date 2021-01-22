    public struct KeyStruct : IEquatable<KeyStruct>
    {
        public string Value1 { get; private set; }
        public long Value2 { get; private set; }
        public KeyStruct(string value1, long value2)
            : this()
        {
            Value1 = value1;
            Value2 = value2;
        }
        public bool Equals(KeyStruct other)
        {
            return Equals(other.Value1, Value1) && other.Value2 == Value2;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (KeyStruct)) return false;
            return Equals((KeyStruct) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value1 != null ? Value1.GetHashCode() : 0)*397) ^ Value2.GetHashCode();
            }
        }
        public static bool operator ==(KeyStruct left, KeyStruct right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(KeyStruct left, KeyStruct right)
        {
            return !left.Equals(right);
        }
    }
