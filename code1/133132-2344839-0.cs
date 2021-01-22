    public delegate object MyDelegate()
    
    public class MyClass
    {
        public MyClass()
        {
             _delegate = MyMethod;
        }
    
        private MyDelegate _delegate;
    
        public SomeObject MyMethod() { return null; }
    }
