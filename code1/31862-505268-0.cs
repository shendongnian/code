    namespace RealCode {
        //using Foo; // can't use this - it breaks DoSomething
        using Handy = Foo.Handy;
        using Bar;
        static class Program {
            static void Main() {
                Handy h = new Handy(); // prove available
                string test = "abc";            
                test.DoSomething(); // prove available
            }
        }
    }
    namespace Foo {
        static class TypeOne {
            public static void DoSomething(this string value) { }
        }
        class Handy {}
    }
    namespace Bar {
        static class TypeTwo {
            public static void DoSomething(this string value) { }
        }
    }
    
