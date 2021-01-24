    public interface IFoo
    {
    }
    public class Foo<T> : IFoo
    {
        public List<T> FooList { get; set; }
    }
    public class Bar
    {
        public List<IFoo> Foos { get; set; }
    }
