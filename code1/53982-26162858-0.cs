    /// <summary>
    /// Wrapper for once inizialization
    /// </summary>
    public class WriteOnce<T>
    {
        private T _value;
        private Int32 _hasValue;
        public T Value
        {
            get { return _value; }
            set
            {
                if (Interlocked.CompareExchange(ref _hasValue, 1, 0) == 0)
                    _value = value;
                else
                    throw new Exception(String.Format("You can't inizialize class instance {0} twice", typeof(WriteOnce<T>)));
            }
        }
        public WriteOnce(T defaultValue)
        {
            _value = defaultValue;
        }
        public static implicit operator T(WriteOnce<T> value)
        {
            return value.Value;
        }
    }
