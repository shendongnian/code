    public class IgnoreCase
    {
        private readonly string _value;
        public IgnoreCase(string s)
        {
            _value = s;
        }
        protected bool Equals(IgnoreCase other)
        {
            return this == other;
        }
        public override bool Equals(object obj)
        {
            return obj != null &&
                   (ReferenceEquals(this, obj) || (obj.GetType() == GetType() && this == (IgnoreCase) obj));
        }
        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }
        public static bool operator ==(IgnoreCase a, IgnoreCase b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
        public static bool operator !=(IgnoreCase a, IgnoreCase b)
        {
            return !(a == b);
        }
        public static implicit operator string(IgnoreCase s)
        {
            return s._value;
        }
        public static implicit operator IgnoreCase(string s)
        {
            return new IgnoreCase(s);
        }
    }
