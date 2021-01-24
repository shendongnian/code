    public interface IFoo
    {
    }
    [DataContract]
    [KnownType(typeof(AFoo))]
    public class Foo : IFoo
    { // this is the Base Class
    }
    public class AFoo : Foo
    {
    }
