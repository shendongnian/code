    public interface IReadOnlyClass
    {
        string SomeProperty { get; }
        int Foo();
    }
    public interface IMutableClass
    {
        string SomeProperty { set; }
        void Foo( int arg );
    }
