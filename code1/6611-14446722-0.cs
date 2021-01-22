    public class MyClass
    {
            private MyClass()
            {
    
            }
    
            static MyClass()
            {
                Instance = new MyClass();
            }
    
            public static MyClass Instance { get; private set; }
    }
