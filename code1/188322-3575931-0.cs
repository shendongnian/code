    public static class Logger
    {
        private static object x = InitObjectX();
        private static object InitObjectX() {
            x.GetHashCode(); // Will throw since x is null.
        }
        public static void LogMethodEnter() 
        { 
            var frame = new StackFrame(1); 
            var method = frame.GetMethod(); 
            Trace.TraceInformation("{0}.{1}.{2}()", method.DeclaringType.Namespace, method.DeclaringType.Name, method.Name); 
            Trace.Indent(); 
        } 
 
        public static void LogMethodExit() 
        { 
            Trace.Unindent(); 
        } 
    } 
