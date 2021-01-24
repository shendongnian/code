    public bool LogAndThrow(Exception ex)
    {
        if (!ex.Data.Contains("Logged"))
        {
            // Replace with real logging
            Console.WriteLine("An exception occurred!");
            ex.Data["Logged"] = true;
        }
        // Always continue up the stack: this never filters
        return false;
    }
    public static bool CatchIfNotLogged(this Exception ex) =>
        !ex.Data.Contains("Logged");
