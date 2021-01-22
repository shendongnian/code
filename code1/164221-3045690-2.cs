    public class Foo : IFoo<Foo>
    {
        public Foo Bar()
        {
            return new Foo();
        }
    }
    public class Cheese : IFoo<Cheese>
    {
        public Cheese Bar()
        {
            return new Cheese();
        }
    }
