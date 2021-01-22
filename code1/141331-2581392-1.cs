    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ImplicitOperatorTest
    {
        class Foo
        {
            private string foo;
    
            public Foo(string foo)
            {
                this.foo = foo;
            }
    
            public static implicit operator string(Foo foo)
            {
                return foo;
            }
    
            public static implicit operator Foo(string foo)
            {
                return new Foo(foo);
            }
        }
    
        interface IFoo
        {
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Foo b = "hello";
            }
        } 
    }
