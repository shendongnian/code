    public class EventHolderCallingClass
    {    
      public delegate void HandleExceptionEventDelegate(Exception exception);
      public event HandleExceptionEventDelegate HandleExceptionEvent ;
    
      void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
        try
        {
          //some operation which caused exception.
        }
        catch(Exception exception)
        {
          if(HandleExceptionEvent!=null)
            HandleExceptionEvent(exception) 
        }
      }
    }
