    public static void Main(string[] args)
    {
    	var c = new MyClass();
    	var d = new MyClass<long>();
    }
    
    class MyClass<T>
    {
        public List<T> ObjectList { get; set; }
    }
    
    class MyClass: MyClass<int>
    {
    }
