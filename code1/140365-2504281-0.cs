    public interface IFoo<T>
    {
        T Value { get; set; }
    }
    public class Foo<T> : Foo, IFoo<T>
    {
        T IFoo.Value
        {
            get { return (T)base.Value; }
            set { base.Value = value; }
        }
    }
