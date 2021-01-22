    class MyClass
    {
        public static MyClass()
        {
            Instance=new MyClass();
        }
    
        public static MyClass Instance {get; private set;}
    
        public void MyMethod() {...}
    }
    //Using the class:
    MyClass.Instance.MyMethod();
