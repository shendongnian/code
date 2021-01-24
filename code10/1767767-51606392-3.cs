    public class OtherClass
    {
        public void OtherMethod()
        {
            string callerClassName = new StackFrame(1).GetMethod().DeclaringType.Name;
            string callerClassNameWithNamespace = new StackFrame(1).GetMethod().DeclaringType.FullName;
            Console.WriteLine("This is the only name of your class:" + callerClassName);
            Console.WriteLine("This is the only name of your class with its namespace:" + callerClassNameWithNamespace);
        }
    }
