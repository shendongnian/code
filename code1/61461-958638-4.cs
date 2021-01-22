    public interface ICustomEnum<T>
    {
        ICustomEnum<T> FromT(T value);
        T Value { get; }
    
        // Implement using a sealed class with a private constructor 
        // that accepts and sets the Value property, 
        // one shared readonly property for each desired value in the enum,
        // and implicit conversions to and from T.
        // Then see this link to get intellisense support
        // that exactly matches a normal enum:
        // http://stackoverflow.com/questions/102084/hidden-features-of-vb-net/102217#102217
        // Note that the completion list only works for VB.
    }
    /// <completionlist cref="MyStringEnum"/>
    public sealed SessionKeys: ICustomEnum<string>
    {
        private string _value;
        public string Value { get { return _value; } } 
    
        private SessionKeys(string value)
        {
            _value = value;
        }
    
        private static SessionKeys _value1 = new MyStringEnum("value1key");
        public static SessionKeys value1 { get { return _value1;} } 
    
        private static MyStringEnum _value2 = new MyStringEnum("value2key");
        public static MyStringEnum value2 { get { return _value2;} } 
    
        public static ICustomEnum<string> FromString(string value) 
        {
            // use reflection or a dictionary here if you have a lot of values
            switch( value )
            {
                case "value1key":
                    return value1;
                case "value2key":
                    return value2;
                default:
                    return null; //or throw an exception
            }
        }
    
        public ICustomEnum<string> FromT(string value) 
        {
            return FromString(value);
        }
    
        public static implicit operator string(SessionKeys item)
        {
            return item.Value;
        }
    
        public static implicit operator SessionKeys(string value)
        {
            return FromString(value);
        }
    }
