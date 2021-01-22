    public struct Celsius : IEquatable<Celsius>
    {
        private readonly Double _value;
        public const string Abbreviation = "°C";
        public Celsius(Double value)
        {
            _value = value;
        }
        public Boolean Equals(Celsius other)
        {
            return _value == other._value;
        }
        public override Boolean Equals(Object other)
        {
            if (!(other is Celsius))
            {
                return false;
            }
            return Equals((Celsius)other);
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public override string ToString()
        {
            return _value + Abbreviation;
        }
        public static explicit operator Celsius(Double value)
        {
            return new Celsius(value);
        }
        public static explicit operator Double(Celsius value)
        {
            return value._value;
        }
        public static Boolean operator >(Celsius l, Celsius r)
        {
            return l._value > r._value;
        }
        public static bool operator <(Celsius l, Celsius r)
        {
            return l._value < r._value;
        }
        public static Boolean operator >=(Celsius l, Celsius r)
        {
            return l._value >= r._value;
        }
        public static bool operator <=(Celsius l, Celsius r)
        {
            return l._value <= r._value;
        }
        public static Boolean operator ==(Celsius l, Celsius r)
        {
            return l._value == r._value;
        }
        public static bool operator !=(Celsius l, Celsius r)
        {
            return l._value != r._value;
        }   
    }
