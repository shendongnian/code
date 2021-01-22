    HandleException(() => {
        throw new Exception("Bad error.");
    });
    public static void HandleException(Action code)
    {
        try
        {
            if (code != null)
                code.Invoke();
        }
        catch
        {
            Console.WriteLine("Error handling");
            throw;
        }
    }
