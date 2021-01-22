    try
    {
        throw new T();
    }
    catch (T)
    {
        Console.WriteLine("Caught passed in exception type");
    }
    catch (Exception)
    {
        Console.WriteLine("Caught general exception");
    }
