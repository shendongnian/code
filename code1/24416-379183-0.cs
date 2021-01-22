    public class foo
    {
        public string bar = "abc";
    }
    public class Container<T>
    {
        T MaybeFoo = default;
    }
    a = new Container<foo>();
    // a.MaybeFoo is null;
