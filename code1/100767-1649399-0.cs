    public class MyClass<T>
    {
        public MyClass(ICollection<T> collection) 
        { 
            /* store reference to collection */ 
        }
    
        // ...
    
        public void store(T obj) 
        { 
            /* put obj into collection */ 
        }
    
        // ...
    }
