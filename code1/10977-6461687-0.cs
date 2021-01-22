    public class MyClass 
    {
      public event EventHandler MyEvent;
    
      public IEnumerable<EventHandler> GetMyEventHandlers()  
      {  
          return from d in MyEvent.GetInvocationList()  
                 select (EventHandler)d;  
      }  
    }
