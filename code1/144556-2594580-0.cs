    using System;
    
    class Program {
        static void Main(string[] args) {
            var t = new Test();
            Action a = () => t.SomeMethod();
            var method = a.Method;
            method.Invoke(a.Target, null);
        }
    }
    class Test {
        public void SomeMethod() {
            Console.WriteLine("Hello world");
        }
    }
