    // For methods that return a value
    private static TResult LogMethod<TResult>(string displayName, Func<TResult> method)
    {
        Console.WriteLine($"{DateTime.Now} - Starting method: {displayName}");
        TResult result = method();
        Console.WriteLine($"{DateTime.Now} - Completed method: {displayName}");
        return result;
    }
    // For void methods
    private static void LogMethod(string displayName, Action method)
    {
        Console.WriteLine($"{DateTime.Now} - Starting method: {displayName}");
        method();
        Console.WriteLine($"{DateTime.Now} - Completed method: {displayName}");
    }
