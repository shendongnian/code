    using System;
    
    class PrivateConstructor {
        private PrivateConstructor() {}
    }
    
    class Program {
        static void Foo<T>() {
            Console.WriteLine(typeof(T));
        }
        
        static void CallFooProxy<T>(T[] array) {
            Foo<T>();
        }
        
        static void CallFoo(Type t) {
            dynamic array = Array.CreateInstance(t, 0);
            CallFooProxy(array);
        }
        
        static void Main(string[] args) {
            CallFoo(typeof(PrivateConstructor));
        }
    }
