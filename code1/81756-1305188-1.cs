    static void Main(string[] args)
    {
        TryCatch(() => { throw new NullReferenceException(); }, 
            new [] { typeof(AbandonedMutexException), typeof(ArgumentException), typeof(NullReferenceException) },
            ex => Console.WriteLine(ex.Message));
    
    }
    
    public static void TryCatch(Action action, Type[] exceptions, Action<Exception> catchBlock)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
             if(exceptions.Any(p => ex.GetType() == p))
             {
                 catchBlock(ex);
             }
             else
             {
                 throw;
             }
        }
    }
