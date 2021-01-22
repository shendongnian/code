    public enum ObjectTypeA
    {
        Undefined,
        Integer,
        Float
    }
    
    public class MyObjectA
    {
        public MyObjectA(object value) : this(value, InfereType(value))
        { }
        public MyObjectA(object value, ObjectTypeA type)
        {
            Value = value;
            Type = type;
        }
        public object Value { get; private set; }
    
        public ObjectTypeA Type
        {
            get;
            private set;
        }
    
        public T ValueAs<T>()
        {
            return (T)Value;
        }
    }
