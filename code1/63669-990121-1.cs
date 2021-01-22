    try
    {
        Console.WriteLine("Yes1");
        throw (new Exception());
        Console.WriteLine("No");
    
    }
    catch
    {
        Console.WriteLine("Yes2");
        throw;
    }
    finally
    {
        Console.WriteLine("Yes3");
    }
    Console.WriteLine("No2");
