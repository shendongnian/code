    if (!ListIsEmpty(dict.Keys)) 
    {
        Console.WriteLine("Dictionary is not empty");
    }
    if (!ListIsEmpty(dict.Keys.Where(x => x.Contains("foo"))
    {
        Console.WriteLine("Dictionary has at least one key containing 'foo'.");
    }
