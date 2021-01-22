    public class MyProp<T>
    {
        private T _value;
    
        public T Value
        {
            get
            {
                // insert desired logic here
                return _value;
            }
            set
            {
                // insert desired logic here
                _value = value;
            }
        }
    
        public static implicit operator T(MyProp<T> value)
        {
            return value.Value;
        }
    
        public static implicit operator MyProp<T>(T value)
        {
            return new MyProp<T> { Value = value };
        }
    }
