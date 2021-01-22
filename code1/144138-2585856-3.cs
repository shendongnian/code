    public class MyClass
    {
        private MyClass(object data1, string data2) { }
    
        public MyClass(object data1) : this(data1, null) { }
    
        public MyClass(string data2) : this(null, data2) { }
    
        public MyClass() : this(null, null) { }
    }
