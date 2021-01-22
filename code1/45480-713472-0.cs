    public void Intercept(IInvocation invocation)
    {
       //do some preprocessing here if needed
       try
       {
          invocation.Proceed()
       }
       catch(Exception e)
       {
          LogException(e);
          throw;
       }
       finally
       {
          //do some postprocessing jf needed
       }
    }
