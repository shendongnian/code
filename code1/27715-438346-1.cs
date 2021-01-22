    using System;
    using Foo = Bar;
    public static class Bar {
        public  static void Test() { Console.WriteLine("outer"); }
    }
    namespace MyNamespace {
        //using Foo = Bar;
    
        public static class Bar {
            public static void Test() { Console.WriteLine("inner"); }
        }
        static class Program {
            static void Main() {
                Foo.Test();
            }
        }
    }
