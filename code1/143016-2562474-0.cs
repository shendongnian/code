    public class SomeObject
    {
        public SomeObject(object value, bool flag)
        {
            Value = value;
            Flag = flag;
        }
    
        public object Value { get; private set; }
        public bool Flag { get; private set; }
    }
