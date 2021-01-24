    try
    {
        // Uncomment this line to catch the generic exception
        // throw new Exception("An exception occurred");
        throw new InvalidOperationException("Operation x is not valid in this context");
    }
    // Comment the following lines to fall into the generic catch exception
    catch (InvalidOperationException)
    {
        // But without the variable we cannot print out the message....
        Console.WriteLine("An invalid operation has been catched");
    }
    catch (Exception)
    {
        Console.WriteLine("An exception raised");
    }
