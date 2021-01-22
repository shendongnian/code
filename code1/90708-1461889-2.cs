    using System;
    
    class Program {
        void Foo<T>() {
            Console.WriteLine(typeof(T));
        }
    
        static void Main(string[] args) {
            dynamic p = new Program();
            p.Foo<string>();
        }
    }
