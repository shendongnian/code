    public interface IFoo
    {
        string Foo { get; set; }
    }
    public static Func<T, bool> GetQuery<T>()
        where T : IFoo
    {
        return i => i.Foo == "Bar";
    }
    // example...
    public class SomeType : IFoo
    {
        public string Foo { get; set; }
    }
    public static Func<SomeType, bool> GetQuery()
    {
        return GetQuery<SomeType>();
    }
