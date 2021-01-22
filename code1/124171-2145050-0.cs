    public class Maybe<T>
    {
        private readonly T _value;
        public Maybe(T value)
        {
            _value = value;
            IsNothing = false;
        }
        public Maybe()
        {
            IsNothing = true;
        }
        public bool IsNothing { get; private set; }
        public T Value
        {
            get
            {
                if (IsNothing)
                {
                    throw new InvalidOperationException("Value doesn't exist");
                }
                return _value;
            }
        }
        public override bool Equals(object other)
        {
            if (IsNothing)
            {
                return (other == null);
            }
            if (other == null)
            {
                return false;
            }
            return _value.Equals(other);
        }
        public override int GetHashCode()
        {
            if (IsNothing)
            {
                return 0;
            }
            return _value.GetHashCode();
        }
        public override string ToString()
        {
            if (IsNothing)
            {
                return "";
            }
            return _value.ToString();
        }
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
        public static explicit operator T(Maybe<T> value)
        {
            return value.Value;
        }
    }
