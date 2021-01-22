    using System;
    using System.Collections;
    
    interface IFoo {
        void Foo<T>(T a) where T : IFoo;
    }
    struct MyStructure : IFoo {
        public void Foo<T>(T a) where T : IFoo {
        }
    }
    public static class Program {
        public static void Main(string[] args) {
            MyStructure s = new MyStructure();
            s.Foo(s);
        }
    }
