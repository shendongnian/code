    public class MyClass
    { 
        private static Dictionary<object, MyClass> cache = 
            new Dictionary<object, MyClass();
    
        private MyClass() { }
    
        public static MyClass GetInstance(object data)
        {
            MyClass output;
    
            if(!cache.TryGetValue(data, out output)) 
                cache.Add(data, output = new MyClass());
    
            return output;           
        }
    }
