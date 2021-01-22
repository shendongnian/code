    public partial class MyClass{ 
    
        public MyClass(){  
            ... normal construction goes here ...
            OnCreated1(); 
            OnCreated2(); 
            ...
        }
    
        public partial void OnCreated1();
        public partial void OnCreated2();
    }
