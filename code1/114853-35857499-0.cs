    [System.Diagnostics.DebuggerNonUserCode]
    public struct NotNull<T> where T : class
    {
        private T _value;
        public T Value
        {
            get
            {
                if (_value == null)
                {
                    throw new Exception("null value not allowed");
                }
                return _value;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("null value not allowed.");
                }
                _value = value;
            }
        }
        public static implicit operator T(NotNull<T> notNullValue)
        {
            return notNullValue.Value;
        }
        public static implicit operator NotNull<T>(T value)
        {
            return new NotNull<T> { Value = value };
        }
    }
