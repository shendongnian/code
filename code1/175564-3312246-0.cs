    class Program
        {
            public class Test
            {
                public bool SomeMethod(string test)
                {
                    return true;
                }
            }
    
            static void Main(string[] args)
            {
    
                Test testObj = new Test();
    
    
                Func<string, bool> rule1 = AddRule(testObj, x => x.SomeMethod);
    
                bool rsult = rule1("ttt");
    
            }
    
            static Func<string, bool> AddRule<T>( T obj, Func<T,Func<string, bool>> func)
            {
                return func(obj);
            }
    
           
    }
