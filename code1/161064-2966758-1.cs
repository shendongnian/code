    [AttributeUsage(AttributeTargets.Method)]
    public class MyDecorator : Attribute
    {
        public void PerformCall(Action action)
        {
           // invoke action (or not)
        }
    }
