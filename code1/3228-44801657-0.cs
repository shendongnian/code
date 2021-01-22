    IEnumerable<int> IteratorBlock()
    {
        Console.WriteLine("Begin");
        yield return 1;
        Console.WriteLine("After 1");
        yield return 2;
        Console.WriteLine("After 2");
        yield return 42;
        Console.WriteLine("End");
    }
