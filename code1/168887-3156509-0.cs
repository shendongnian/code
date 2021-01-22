    class Union {
        public interface AllowedType<T> { };
        
        internal object val;
        
        internal System.Type type;
    }
    
    static class UnionEx {
        public static T As<U,T>(this U x) where U : Union, Union.AllowedType<T> {
            return x.type == typeof(T) ?(T)x.val : default(T);
        }
    
        public static void Set<U,T>(this U x, T newval) where U : Union, Union.AllowedType<T> {
            x.val = newval;
            x.type = typeof(T);
        }
        
        public static bool Is<U,T>(this U x) where U : Union, Union.AllowedType<T> {
            return x.type == typeof(T);
        }
    }
    
    class MyType : Union, Union.AllowedType<int>, Union.AllowedType<string> {}
    
    class TestIt
    {
        static void Main()
        {
            MyType bla = new MyType();
            bla.Set(234);
            System.Console.WriteLine(bla.As<MyType,int>());
            System.Console.WriteLine(bla.Is<MyType,string>());
            System.Console.WriteLine(bla.Is<MyType,int>());
            
            bla.Set("test");
            System.Console.WriteLine(bla.As<MyType,string>());
            System.Console.WriteLine(bla.Is<MyType,string>());
            System.Console.WriteLine(bla.Is<MyType,int>());
            
            // compile time errors!
            // bla.Set('a'); 
            // bla.Is<MyType,char>()
        }
    }
