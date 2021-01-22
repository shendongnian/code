    try
    {
        Console.WriteLine("Yes1");
        throw (new Exception());
        Console.WriteLine("No1");
    
    }
    catch
    {
        Console.WriteLine("Yes2");
        throw;
        Console.WriteLine("No2");
    }
    finally
    {
        Console.WriteLine("Yes3");
    }
    Console.WriteLine("No3");
