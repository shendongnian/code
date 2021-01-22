    using System;
    using System.Diagnostics;
    
    [Foo]
    class Program {
        static void Main(string[] args) {
            var t = typeof(Program);
            var ok = Attribute.IsDefined(typeof(Program), typeof(FooAttribute));
            Debug.Assert(ok);
        }
    }
    
    class FooAttribute : Attribute { }
