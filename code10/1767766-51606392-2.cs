    public class OtherClass
    {
        public void OtherMethod()
        {
            StackTrace stackTrace = new StackTrace();
            string callerClassName = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            string callerClassNameWithNamespace = stackTrace.GetFrame(1).GetMethod().DeclaringType.FullName;
            Console.WriteLine("This is the only name of your class:" + callerClassName);
            Console.WriteLine("This is the only name of your class with its namespace:" + callerClassNameWithNamespace);
        }
    }
