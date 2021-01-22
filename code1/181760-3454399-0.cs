    public abstract class BaseClass
    {
        private BaseClass(Object param)
        {
            //Do something with parameters
        }
        //Provide various methods that descendant classes will know how to perform
        public static BaseClass FromObject(Object value)
        {
            //Based on object, choose which type of derived class to construct...
        }
        private class HiddenDerivedA : BaseClass
        {
            public HiddenDerivedA(Object value)
                : base(value)
            {
            }
        }
        private class HiddenDerivedB : BaseClass
        {
            public HiddenDerivedB(Object value)
                : base(value)
            {
            }
        }
    }
