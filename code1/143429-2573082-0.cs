    public enum ExceptionAction { Throw, ReturnDefault };
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExceptionBehaviorAttribute : Attribute
    {
        public ExceptionBehaviorAttribute(Type exceptionType, ExceptionAction action)
        {
            this.exceptionType = exceptionType;
            this.action = action;
        }
        public Type ExceptionType { get; private set; }
        public ExceptionAction Action { get; private set; }
    }
