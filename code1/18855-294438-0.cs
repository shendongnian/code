    [AttributeUsage(AttributeTargets.Class)]
    public class ClassDescriptionAttribute : Attribute
    {
        public ClassDescriptionAttribute(Type KeyDataType)
        {
            _KeyDataType = KeyDataType;
        }
        public Type KeyDataType
        {
            get { return _KeyDataType; }
        }
        private Type _KeyDataType;
    }
    [ClassDescriptionAttribute(typeof(string))]
    class Program
    {
        ....
    }
