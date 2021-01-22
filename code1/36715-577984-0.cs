    public class RestrictedRange<T> where T : IComparable
    {        
        private T _Value;
        public T MinValue { get; private set; }
        public T MaxValue { get; private set; }
        public RestrictedRange(T minValue, T maxValue)
            : this(minValue, maxValue, minValue)
        {
        }
        public RestrictedRange(T minValue, T maxValue, T value)
        {
            if (minValue.CompareTo(maxValue) > 0)
            {
                throw new ArgumentOutOfRangeException("minValue");
            }
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.Value = value;
        }
        public T Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if ((0 < MinValue.CompareTo(value)) || (MaxValue.CompareTo(value) < 0))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _Value = value;
            }
        }
        public static implicit operator T(RestrictedRange<T> value)
        {
            return value.Value;
        }        
        public override string ToString()
        {
            return MinValue + " <= " + Value + " <= " + MaxValue;
        }
    }
