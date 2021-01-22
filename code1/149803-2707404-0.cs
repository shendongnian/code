    public class SafeValue
    {
        private string _value;
        public static readonly SafeValue Value1 = new SafeValue("value1");
        public static readonly SafeValue Value2 = new SafeValue("value2");
        private SafeValue(string value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value;
        }
    }
