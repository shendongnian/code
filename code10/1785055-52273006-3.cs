    public static void Main(string[] args)
    {
        try
        {
            throw new UnauthorizedAccessException("Cannot access this path.");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"I am not continuing. Reason: {e.Message}.");
        }
        // Important, otherwise we would simply exit.
        Console.WriteLine("Or look, I am in fact continuing :)");     }
