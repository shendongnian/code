    static void Foo()
    {
        var x = 100.00M;
        Console.WriteLine(x);
    }
    static void Bar()
    {
        var x = (decimal)100.00; // compiled as 100M - extended .00 precision lost
        Console.WriteLine(x);
    }
