    class Base
    {
        internal virtual void Foo()
        {
            Console.WriteLine("Foo from Base");
        }
    }
    class Derived : Base
    {
        internal override void Foo()
        {
            Console.WriteLine("Foo from Derived");
        }
    }
