    using System;
    using System.Diagnostics;
    
    [Foo]
    class Program {
        static void Main(string[] args) {
            var ok = Attribute.IsDefined(typeof(Program), typeof(FooAttribute));
            Debug.Assert(ok);
        }
    }
    
    class FooAttribute : Attribute { }
