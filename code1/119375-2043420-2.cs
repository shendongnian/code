    public void AttemptCall<TException>(Action action)
        where TException : Exception
    {
        try
        {
            action();
        }
        catch(TException e)
        {
             state.ActUponExcpetion(e);
             throw;
        }
    }
