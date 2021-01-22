    public class MyClass
        {
                private MyClass()
                {
        
                }
        
                static MyClass()
                {
                    Instance = new MyClass();
                }
        
                private static MyClass instance;
    
                public static MyClass Instance
                {
                    get
                    {
                        return instance;
                    }
                    private set
                    {
                        instance = value;
                    }
                }
        }
