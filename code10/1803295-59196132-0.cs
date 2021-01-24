    public class StringClob
    {
        public StringClob()
        {
        }
    
        public StringClob(string value)
        {
            Value = value;
        }
    
        public virtual string Value { get; protected set; }
    }
