    public class OtherClass
        {
            public void OtherMethod()
            {
                StackTrace stackTrace = new StackTrace();
    
                string className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
                string classNameWithNamespace = stackTrace.GetFrame(1).GetMethod().DeclaringType.FullName;
            }
        }
