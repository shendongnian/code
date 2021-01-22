    public void test()
    {
        var test = "test";
        Console.WriteLine("Old: " + test);
        Console.WriteLine("New: " + test.LinqReplace(0, 4, "SOMEPIG")
                                        .LinqReplace(4, 0, "terrific")
                                        .AsString());
    }
