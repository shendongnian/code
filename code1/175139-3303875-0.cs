    try
    {
    //your code goes here
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occured: {0}", ex.Message);
        if (ex.InnerException != null)
           Console.WriteLine("Inner Exception: {0}", ex.InnerException.Message);
        Console.WriteLine("Stack Trace: {0}", ex.StackTrace);
    }
