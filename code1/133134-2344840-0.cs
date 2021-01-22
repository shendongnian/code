    public delegate void MyDelegate<T>(T obj)
    
    public class MyClass
    {
        public MyClass()
        {
            _delegate = MyMethod;
        }
    
        private MyDelegate<SomeObject> _delegate;
    
        public void MyMethod(SomeObject obj)
        {
        }
    }
