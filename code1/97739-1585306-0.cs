    class A
    {
        public void Foo()
        {
            Console.WriteLine("A.Foo()");
        }
    }
    
    class B : A
    {
        public new void Foo()
        {
            Console.WriteLine("B.Foo()");
        }
    }
    ...
    A x = new A();
    x.Foo(); // prints "A.Foo()"
    B y = new B();   
    y.Foo(); // prints "B.Foo()"
    A z = b;
    z.Foo(); // prints "A.Foo()", not "B.Foo()"!
