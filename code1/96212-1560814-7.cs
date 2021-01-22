    private SkipOnError(Action action)
    {
        try 
        {
            action();
        }
        catch
        {
        }
    }
