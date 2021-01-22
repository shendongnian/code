    class MyClass {  
        public MyClass(Action<int> myMethod)
        {
            this.MyMethod = myMethod ?? x => { };
        }
    
        public readonly Action<int> MyMethod;
    }
