    public class Nullable<T>
    {
        public Nullable(T value)
        {
            _value = value;
            _hasValue = true;
        }
    
        public Nullable()
        {
            _hasValue = false;
        }
    
        [XmlText]
        public T Value
        {
            get
            {
                if (!HasValue)
                    throw new InvalidOperationException();
                return _value;
            }
            set
            {
                _value = value;
                _hasValue = true;
            }
        }
    
        [XmlIgnore]
        public bool HasValue
            { get { return _hasValue; } }
    
        public T GetValueOrDefault()
            { return _value; }
        public T GetValueOrDefault(T i_defaultValue)
            { return HasValue ? _value : i_defaultValue; }
    
        public static explicit operator T(Nullable<T> i_value)
            { return i_value.Value; }
        public static implicit operator Nullable<T>(T i_value)
            { return new Nullable<T>(i_value); }
    
        public override bool Equals(object i_other)
        {
            if (!HasValue)
                return (i_other == null);
            if (i_other == null)
                return false;
            return _value.Equals(i_other);
        }
    
        public override int GetHashCode()
        {
            if (!HasValue)
                return 0;
            return _value.GetHashCode();
        }
    
        public override string ToString()
        {
            if (!HasValue)
                return "";
            return _value.ToString();
        }
    
        bool _hasValue;
        T    _value;
    }
