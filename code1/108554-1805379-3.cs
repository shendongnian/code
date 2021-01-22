    class MyClass : IDisposable
    {
        public static MyClass()
        {
            Instance=new MyClass();
        }
    
        public static MyClass Instance {get; private set;}
    
        public void MyMethod() {...}
        public void Dispose()
        {
            //...
        }
        ~MyClass()
        {
            //Your destructor goes here
        }
    }
    //Using the class:
    MyClass.Instance.MyMethod();
