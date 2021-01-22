    for (int i = 0; i < 10; i++)
    {
        try
        {
            throw new Exception();
        }
        catch
        {
        }
        Console.WriteLine("I'm after the exception");
    }
    for (int i = 0; i < 10; i++)
    {
        try
        {
            throw new Exception();
        }
        catch
        {
            continue;
        }
        Console.WriteLine("this code here is never called");
    }
