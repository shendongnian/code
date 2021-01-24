    [AttributeUsage(AttributeTargets.Method)]
    public class HandlesAttribute : Attribute
    {
        public Type MessageType { get; private set; }
        public HandlesAttribute(Type messageType)
        {
            MessageType = messageType;
        }
    };
