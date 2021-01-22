    try
    {
        throw new T();
    }
    catch (T)
    {
        Console.WriteLine();
    }
    catch (Exception)
    {
        Console.WriteLine("Caught general exception");
    }
