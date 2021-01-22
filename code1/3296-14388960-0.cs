    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InstanceAttribute : Attribute
    {
        public bool IsConstructorCall { get; private set; }
        public object[] Values { get; private set; }
        public InstanceAttribute() : this(true) { }
        public InstanceAttribute(object value) : this(false, value) { }
        public InstanceAttribute(bool isConstructorCall, params object[] values)
        {
            IsConstructorCall = isConstructorCall;
            Values = values ?? new object[0];
        }
    }
