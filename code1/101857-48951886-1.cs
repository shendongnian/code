    private static void Main()
    {
        var foo = new Foo();
        foo.TestMeDude<string>();
        foo.TestMeDude<int>();
        foo.TestMeDude<Foo>();
        foo.TestMeDude<string>();
        Console.ReadLine();
    }
