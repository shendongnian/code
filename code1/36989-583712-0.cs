    public struct S2kBool : IEquatable<bool>
    {
        public bool Value { get; set; }
        public bool Equals(bool other)
        {
            return Value == other;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public static bool operator ==(bool left, S2kBool right)
        {
            return right.Equals(left);
        }
        public static bool operator !=(bool left, S2kBool right)
        {
            return !(left == right);
        }
        public static bool operator ==(S2kBool left, bool right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(S2kBool left, bool right)
        {
            return !(left == right);
        }
    }
