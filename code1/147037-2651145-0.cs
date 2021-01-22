    private static void BarBar(Foo f)
    {
        Console.WriteLine(f.GetHashCode());
        f = new Foo();
    }
    private static void FooFoo(ref Foo f)
    {
        Console.WriteLine(f.GetHashCode());
        f = new Foo();
    }
