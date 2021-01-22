    public void AttemptCall<TException>(Action action)
        where TException : Exception
    {
        try
        {
            action();
        }
        catch(TException e)
        {
             if(e is TException)
                 state.ActUponExcpetion(e);
             throw;
        }
    }
