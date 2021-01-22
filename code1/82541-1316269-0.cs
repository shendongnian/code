    public abstract class Handler
    {
      public abstract void Handle(string event);
    }
    
    public static class HandlerExtensions
    {
      public static void RaiseEvent(this IEnumerable<Handler> handlers, string event)
      {
         foreach(var handler in handlers) { handler.Handle(event); }     
      }
    }
    
    ...
    
    List<Handler> handlers = new List<Handler>();
    handlers.Add(new Handler1());
    handlers.Add(new Handler2());
    
    handlers.RaiseEvent("event 1");
    handlers.RaiseEvent("event 2");
    handlers.RaiseEvent("event 3");
