    public class SomeClass<U>
    {
        private Func<U>;
    
        public SomeClass(Func<U> someDelegate)
        {
            this.someDelegate = someDelegate;
        }
    
        public U Run()
        {
            return someDelegate();
        }
    }
