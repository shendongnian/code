    public class BaseFieldValue<T>
    {
        public BaseFieldValue()
        {
            // ...
        }
        public BaseFieldValue(StringWrapper value)
        {
            // ...
        }
        public BaseFieldValue(T value)
        {
            // ...
        }
        public class StringWrapper
        {
            private string _value;
            public static implicit operator string(StringWrapper sw)
            {
                return sw._value;
            }
            public static implicit operator StringWrapper(string s)
            {
                return new StringWrapper { _value = s };
            }
        }
    }
