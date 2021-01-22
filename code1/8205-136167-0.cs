    public class LogExceptionAttribute : OnExceptionAspect
    {
     public override void OnException(MethodExecutionEventArgs eventArgs)
     {
      log.error("Exception occurred in method {0}", eventArgs); 
     }
    }
    [LoggingOnExceptionAspect]
    public foo(int number, string word, Person customer)
    {
       \\ ... something here throws an exception
    }
