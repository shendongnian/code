    try
    {
        throw new T();
    }
    catch (T tex)
    {
        Console.WriteLine("Caught passed in exception type");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Caught general exception");
    }
