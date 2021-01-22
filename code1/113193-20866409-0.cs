    public class Wrapper //or may be generic?
    {
        public object Value { get; set; }
    
        public Wrapper(object value)
        {
            Value = value;
        }
    }
