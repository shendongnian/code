    try
    {
        SetCurrentDirectory(longPath);
    }
    catch(PathTooLongException exc)
    {
        Console.WriteLine("The pathname was too long");
    }
