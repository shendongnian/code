    class Base { }
    class Derived : Base { }
    class Foo
    {
        void Test()
        {
            Base a = new Base();
            Overload(a);    // prints "base"
            Derived b = new Derived();
            Overload(b);    // prints "derived"
            // dispatched based on c's declared type!
            Base c = new Derived();
            Overload(c);    // prints "base"
        }
        void Overload(Base obj)    { Console.WriteLine("base"); }
        void Overload(Derived obj) { Console.WriteLine("derived"); }
    }
