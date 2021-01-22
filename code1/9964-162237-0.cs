    /// <summary>
    /// Represents the return value from an operation that might fail
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Maybe<T>
    {
        T _value;
        bool _hasValue;
        public Maybe(T value)
        {
            _value = value;
            _hasValue = true;
        }
        public Maybe()
        {
            _hasValue = false;
            _value = default(T);
        }
        
        public bool Success
        {
            get { return _hasValue; }
        }
        public T Value
        {
            get 
                { // could throw an exception if _hasValue is false
                  return _value; 
                }
        }
    }
