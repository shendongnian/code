    public void AttemptCall(Action action, Predicate<Exception> match)
    {
        try
        {
            action();
        }
        catch(Exception e)
        {
            if(match(e))
                state.ActUponException(e);
            throw;
        }
    }
