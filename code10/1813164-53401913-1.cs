    public class MyImmutableClass
    {
        public MyImmutableClass(string stringValue, int intValue)
        {
            StringValue = stringValue;
            IntValue = intValue;
        }
        public string StringValue { get; }
        public int IntValue { get; }
    }
