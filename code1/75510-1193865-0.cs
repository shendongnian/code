        using System;
        namespace Polymorphism
        {
            class A
            {
                public void Foo() { Console.WriteLine("A::Foo()"); }
            }
            class B : A
            {
                public new void Foo() { Console.WriteLine("B::Foo()"); }
            }
            class Test
            {
                static void Main(string[] args)
                {
                    A a;
                    B b;
                    a = new A();
                    b = new B();
                    a.Foo();  // output --> "A::Foo()"
                    b.Foo();  // output --> "B::Foo()"
                    a = new B();
                    a.Foo();  // output --> "A::Foo()"
                }
            }
        }
