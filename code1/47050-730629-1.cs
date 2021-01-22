    class Base
    {
        public virtual void Override() { Console.WriteLine("base"); }
    }
    class Derived : Base
    {
        public override void Override() { Console.WriteLine("derived"); }
    }
    class Foo
    {
        void Test()
        {
            Base a = new Base();
            a.Override();   // prints "base"
            Derived b = new Derived();
            b.Override();    // prints "derived"
            // dynamically dispatched based type of object stored in c!
            Base c = new Derived();
            c.Override();    // prints "derived"
        }
        void Overload(Base obj) { Console.WriteLine("base"); }
        void Overload(Derived obj) { Console.WriteLine("derived"); }
    }
