    using System;
    using System.Collections;
    
    interface IFoo {
        void Foo();
    }
    struct MyStructure : IFoo {
        public void Foo() {
        }
    }
    public static class Program {
        static void MethodDoesNotBoxArguments<T>(T t) where T : IFoo {
            t.Foo();
        }
        static void Main(string[] args) {
            MyStructure s = new MyStructure();
            MethodThatDoesNotBoxArguments(s);
        }
    }
