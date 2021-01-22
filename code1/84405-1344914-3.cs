    public class MyWrapperClass<T> where T : struct 
    {
        public Nullable<T> Item { get; set; }	
    }
    
    public class MyClass<T> where T : class 
    {
    
    }
