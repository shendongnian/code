    private SkipOnError(Action action, Type exceptionToSkip)
    {
        try 
        {
            action();
        }
        catch (Exception e)
        {
            if (e.GetType() != exceptionToSkip) throw;            
        }
    }
