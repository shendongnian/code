    class Base
    {
        internal void Foo()
        {
            Console.WriteLine("Foo from Base");
        }
    }
    class Derived : Base
    {
        internal new void Foo()
        {
            Console.WriteLine("Foo from Derived");
        }
    }
    static void Main()
    {
        Base b = new Derived();
        b.Foo();
    }
