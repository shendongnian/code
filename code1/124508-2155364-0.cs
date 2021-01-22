    public static class Listener {
      public static void Once(this object eventSource, string eventName, EventHandler handler) {
        var eventInfo = eventSource.GetType().GetEvent(eventName);
        EventHandler internalHandler = null;
        internalHandler = (src, args) => {
          handler(src, args);
          eventInfo.RemoveEventHandler(eventSource, internalHandler);
        };
        eventInfo.AddEventHandler(eventSource, internalHandler);
      }
      public static void Once<U>(this object eventSource, string eventName, EventHandler<U> handler) where U : EventArgs {
        var eventInfo = eventSource.GetType().GetEvent(eventName);
        EventHandler<U> internalHandler = null;
        internalHandler = (src, args) => {
          handler(src, args);
          eventInfo.RemoveEventHandler(eventSource, internalHandler);
        };
        eventInfo.AddEventHandler(eventSource, internalHandler);
      }
    }
