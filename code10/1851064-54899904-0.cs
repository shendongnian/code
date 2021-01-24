    public interface IFoo
    {
        string Foo();
    }
    
    public interface IBar
    {
        void Bar();
    }
    
    
    public class Foo : IFoo
    {
        string IFoo.Foo()
        {
            return "Foo";
        }
    }
    
    public class Bar : IBar
    {
        private readonly IFoo _foo;
    
        public Bar(IFoo foo)
        {
            _foo = foo;
        }
    
        void IBar.Bar()
        {
            Console.WriteLine($"Bar {_foo.Foo()}");
        }
    }
