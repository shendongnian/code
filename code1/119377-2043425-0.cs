    private readonly List<Exception> ignored = new List<Exception>();
    public void Ignore<TException>() 
        where TException : Exception
    {
        Type type = typeof(TException);
        if(ignored.Contains(type))
            return;
        ignored.Add(type);
    }
    public void AttemptCall(Action action)
    {
         try
         {
             action();
         }
         catch(Exception e)
         {
             if(!ignore.Contains(e.GetType()))
                 state.ActUponException(e);
    
             throw;
         }
    }
