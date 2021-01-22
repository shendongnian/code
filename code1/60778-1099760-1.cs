    public interface IFoo
    {
        void DoFoo();
    }
    public class Foo : IFoo
    {
        public void DoFoo() { Console.WriteLine("This is _not_ the interface method."); }
        void IFoo.DoFoo() { Console.WriteLine("This _is_ the interface method."); }
    }
    Foo foo = new Foo();
    foo.DoFoo();               // This calls the non-interface method
    IFoo foo2 = foo;
    foo2.DoFoo();              // This calls the interface method
