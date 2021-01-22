    namespace Foo
    {
        class A
        {
            protected internal void D() { Console.WriteLine(this.ToString() + " says 'Blah'"); }
        }
    }
    
    namespace Bar
    {
        class B : Foo.A 
        {
            public B()
            {
            }
        }
    }
    
    namespace Baz
    {
        class C : Foo.A
        {
            public C()
            {
                D();
                Bar.B b = new Bar.B();
                b.D();
    
                Foo.A a = new Foo.A();
                a.D();
            }
        }
    }
