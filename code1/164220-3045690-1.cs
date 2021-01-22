    public class Foo : IFoo<Foo>
    {
        Foo Bar()
        {
            return new Foo();
        }
    }
    public class Cheese : IFoo<Cheese>
    {
        Cheese Bar()
        {
            return new Cheese();
        }
    }
