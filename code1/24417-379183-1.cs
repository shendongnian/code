    public class foo
    {
        public string bar = "abc";
    }
    public class Container<T> where T : new()
    {
        T MaybeFoo = new T();
    }
    a = new Container<foo>();
    Console.WriteLine( ((Foo)a.MaybeFoo).bar )  // prints "abc"
