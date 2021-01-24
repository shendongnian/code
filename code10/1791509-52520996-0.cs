    public class MyWrapper
    {
        public static void MyWrapperMethod(IMyWrapper wrapped, Action doStuff)
        {
            try
            {
                doStuff();
            }
            finally
            {
                wrapped.Do();
            }
        }
        public static void MyWrapperMethod(object notWrapped, Action doStuff)
        {
            doStuff();
        }
    }
