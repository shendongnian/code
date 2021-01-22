    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class IDEMessageAttribute : Attribute
    {
        public string Message;
        public IDEMessageAttribute(string message);
    }
