    public class MyClass
    {
        public static void A()
        {
           B();
        }
    
        public static void B()
        {
            var stackTrace = new StackTrace();
    
            if (stackTrace.FrameCount < 1 || stackTrace.GetFrame(1).GetMethod() != typeof(MyClass).GetMethod("A"))
                  throw new InvalidOperationException("Not called from A()");
        }
    }
