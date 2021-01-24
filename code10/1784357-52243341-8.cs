    try
    {
        // Uncomment this line to catch the generic exception
        // throw new Exception("message");
        throw new InvalidOperationException("message");
    }
    // Comment the following lines to fall into the generic catch exception
    catch (InvalidOperationException)
    {
        Console.WriteLine("An invalid operation has been catched");
    }
    catch (Exception)
    {
        Console.WriteLine("An exception raised");
    }
