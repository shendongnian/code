    public class FooFactory : TypeBasedFactory<Bar, Foo>
    {
        private Foo1 CreateFoo1(Bar1 bar1)
        {
            return new Foo1(bar1.Id, bar1.Name, ...);
        }
        private Foo2 CreateFoo2(Bar2 bar2)
        {
            return new Foo2(bar2.Description, ...);
        }
    }
