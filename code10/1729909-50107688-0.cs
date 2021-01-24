    public class Foo : IFoo<Bar>
    {
        public virtual ICollection<Bar> Bars { get; set; }
    }
    
    public class Bar : IBar<Foo>
    {
        public virtual Foo Foo { get; set; }
    }
    public interface IFoo<T>
    {
        ICollection<T> Bars { get; set; }
    }
    
    public interface IBar<T>
    {
        T Foo { get; set; }
    }
