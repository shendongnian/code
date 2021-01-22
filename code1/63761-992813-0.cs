    public class MyBaseClass
        {
            public MyBaseClass ( int arg2, string arg1,string ar3)
            { }
        }
    
        public class MyClass : MyBaseClass
        {
            public MyClass (int argument) : base (argument, "not supplied", "hard-coded") 
            { }
    
        }
