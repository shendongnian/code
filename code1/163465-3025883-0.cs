    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            var pi = typeof(Program).GetProperty("Prop");
            var ok = Attribute.IsDefined(pi, typeof(FooAttribute));
            Debug.Assert(ok);
        }
        [Foo]
        int Prop { get; set; }
    }
    
    class FooAttribute : Attribute { }
