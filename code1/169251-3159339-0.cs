    public class MyClassWhichIsAbstractExceptForMe
    {
        // Allow derived classes but prevent public construction.
        protected MyClassWhichIsAbstractExceptForMe()
        {
        }
        // Allow internal construction
        internal static MyClassWhichIsAbstractExceptForMe Create()
        {
            return new MyClassWhichIsAbstractExceptForMe();
        }
    }
