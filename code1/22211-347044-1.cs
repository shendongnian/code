    try
    {
        Console.WriteLine("x");
        try
        {
            Console.WriteLine("a");
            yield return 10;
            Console.WriteLine("b");
        }
        catch (Something e)
        {
            Console.WriteLine("y");
            if ((DateTime.Now.Second % 2) == 0)
                throw;
        }
    }
    catch (Something e)
    {
        Console.WriteLine("Catch block");
    }
    Console.WriteLine("Post");
