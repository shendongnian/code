    static void Main(string[] args)
    {
        Console.WriteLine("Beginning demo of how finally clause doesn't get executed");
        try
        {
            Console.WriteLine("Inside try but before exception.");
            throw new Exception("Exception #1");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Inside catch for the exception '{ex.Message}' (before throwing another exception).");
            throw;
        }
        finally
        {
            Console.WriteLine("This never gets executed, and that seems very, very wrong.");
        }
        Console.WriteLine("This never gets executed, but I wasn't expecting it to."); 
        Console.ReadLine();
    }
