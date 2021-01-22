    try
    {
        Console.WriteLine("a");
        yield return 10;
        Console.WriteLine("b");
    }
    catch (Something e)
    {
        Console.WriteLine("Catch block");
    }
    Console.WriteLine("Post");
