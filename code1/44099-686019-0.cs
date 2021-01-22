    static void Foo()
    {
        var x = 100F;
        Console.WriteLine(x);
    }
    static void Bar()
    {
        var x = (float)100; // compiled as "ldc.r4 100" - **not** a cast
        Console.WriteLine(x);
    }
