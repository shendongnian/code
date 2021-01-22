    class TestClass
    {
        public static void Hello()
        {
    
            Console.WriteLine("World!!!");
        }
    }
    
    public static void Test<T>() where T : class
    {
        Type type = typeof(T);
        type.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(m => m.Name == "Hello")
            .Invoke(null, null);
        
    }     
   
