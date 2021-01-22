    public class SomeClass
    {
        public void SomeMethod()
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            var name = method.Name;
        }
    }
