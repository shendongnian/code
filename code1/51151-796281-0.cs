        public class MyClass
        {
    
            public MyClass Where<T>(Func<MyClass, T> predicate)
            {
                return new MyClass { StringProp = "Hello World" };
            }
    
            public MyClass Select<T>(Func<MyClass, T> predicate)
            {
                return new MyClass ();
            }
    
            
    
            public string StringProp { get; set; }
        }
