    class Foo : IDisposable
    {
        public void Dispose() {}
    }
    static void Use(MySingleton<Foo> foo)
    {
        foo.Get();
    }
    static void Use(Func<Foo> foo)
    {
        foo();
    }
