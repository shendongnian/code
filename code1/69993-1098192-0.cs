    public int SomeMethod(T t) where T : ISomeInterface
    {
        // ...
    }
    public interface ISomeInterface
    {
        int Age { get; }
    }
