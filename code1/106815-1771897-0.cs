    // Your interface
    interface IFoo { void A(); void B; }
    // A "default" implementation of that interface
    abstract class FooBase : IFoo
    {
        public abstract void A();
        public void B()
        {
            Console.WriteLine("B");
        }
    }
    // A class that implements IFoo by reusing FooBase partial implementation
    class Foo : FooBase
    {
        public override void A()
        {
            Console.WriteLine("A");
        }
    }
    // This is a different class you may want to inherit from
    class Bar
    {
        public void C()
        {
            Console.WriteLine("C");
        }
    }
    // A class that inherits from Bar and implements IFoo
    class FooBar : Bar, IFoo
    {
        public void A()
        {
            Console.WriteLine("Foobar.A");
        }
        public void B()
        {
            Console.WriteLine("Foobar.B");
        }
    }
