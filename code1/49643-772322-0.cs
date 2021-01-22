    using System;
    using System.Reflection;
    
    class Foo {
        public override string ToString() {
            return Bar; // to prove it worked
        }
        public string Bar { private get; set; }
    }
    class Program {
        static void Main() {
            Foo foo = new Foo();
            MethodInfo setMethod = typeof(Foo).GetProperty("Bar").GetSetMethod();
            Action<Foo, string> setter = (Action<Foo, string>)
                Delegate.CreateDelegate(typeof(Action<Foo, string>), setMethod);
            setter(foo, "abc");
            string s = foo.ToString(); // to prove it worked
        }
    }
