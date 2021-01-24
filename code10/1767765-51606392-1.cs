    public class OtherClass
    {
        public void OtherMethod()
        {
            StackTrace stackTrace = new StackTrace();
    
            string className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            string classNameWithNamespace = stackTrace.GetFrame(1).GetMethod().DeclaringType.FullName;
    
            Console.WriteLine("This is the only name of your calling class:" + className);
            Console.WriteLine("This is the only name of your calling class with its namespace:" + classNameWithNamespace);
        }
    }
