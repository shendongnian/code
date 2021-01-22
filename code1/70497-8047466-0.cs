    public class NonEmptyString : IComparable<NonEmptyString>, ...
    {
        private readonly string _value;
        public NonEmptyString(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {                
                throw NewStringIsEmptyException("value");
            }
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
        ...
    }
    public class NonWhiteSpaceString : NonEmptyString
    {
        ....
    }
