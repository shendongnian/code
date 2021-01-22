    try
    {
        // Your code here
    }
    catch (Exception ex)
    {
        // This will tell you the Exception
        Console.WriteLine("Exception type: {0}", ex.GetType());
        // or, if you use the example from the link above
        LogMessageToFile(String.Format("Exception type: {0}", ex.GetType));
    }
