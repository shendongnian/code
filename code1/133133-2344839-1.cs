    public delegate void MyDelegate(SomeObject obj)
    
    public class MyClass
    {
        public MyClass()
        {
             _delegate = MyMethod;
        }
    
        private MyDelegate _delegate;
    
        public void MyMethod(object obj) {}
    }
