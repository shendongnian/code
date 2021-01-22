    using System;
    class Program {
        void Foo<T>() {
            Console.WriteLine(typeof(T));
        }
    
        static void Main(string[] args) {
            dynamic p = new Program();
            dynamic v = GetRandomInstance();
            
            // Now to call p.Foo<T> where T is the type of v's value...
            Dummy(v, p);
        }
        
        static void Dummy<T>(T t, Program p) {
            p.Foo<T>();
        }
        
        static object GetRandomInstance() {
            return DateTime.Now.Hour > 10 ? "hello" : (object) 10;
        }
    }
