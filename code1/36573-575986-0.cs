    public struct Probability : IEquatable<Probability>, IComparable<Probability>
    {
        public static bool operator ==(Probability x, Probability y)
        {
            return x.Equals(y);
        }
        public static bool operator !=(Probability x, Probability y)
        {
            return !(x == y);
        }
        public static bool operator >(Probability x, Probability y)
        {
            return x.CompareTo(y) > 0;
        }
        public static bool operator <(Probability x, Probability y)
        {
            return x.CompareTo(y) < 0;
        }
        public static Probability operator +(Probability x, Probability y)
        {
            return new Probability(x._value + y._value);
        }
        public static Probability operator -(Probability x, Probability y)
        {
            return new Probability(x._value - y._value);
        }
        private decimal _value;
        public Probability(decimal value) : this()
        {
            if(value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            _value = value;
        }
        public override bool Equals(object obj)
        {
            return obj is Probability && Equals((Probability) obj);
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public override string ToString()
        {
            return (_value * 100).ToString() + "%";
        }
        public decimal ToDouble()
        {
            return _value;
        }
        public bool Equals(Probability other)
        {
            return other._value.Equals(_value);
        }
        public int CompareTo(Probability other)
        {
            return _value.CompareTo(other._value);
        }
    }
