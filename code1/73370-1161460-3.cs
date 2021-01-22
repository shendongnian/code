    void FooMethod(int foo)
    {
        FooMethod(foo, "foobar");
    }
    void FooMethod(int foo, string bar)
    {
        Console.WriteLine("{0}, {1}", foo, bar);
    }
