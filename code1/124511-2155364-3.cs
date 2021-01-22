    public static class Listener {
      public static void ListenOnce(this object eventSource, string eventName, EventHandler handler) {
        var eventInfo = eventSource.GetType().GetEvent(eventName);
        EventHandler internalHandler = null;
        internalHandler = (src, args) => {
          handler(src, args);
          eventInfo.RemoveEventHandler(eventSource, internalHandler);
        };
        eventInfo.AddEventHandler(eventSource, internalHandler);
      }
      public static void ListenOnce<TEventArgs>(this object eventSource, string eventName, EventHandler<TEventArgs> handler) where TEventArgs : EventArgs {
        var eventInfo = eventSource.GetType().GetEvent(eventName);
        EventHandler<TEventArgs> internalHandler = null;
        internalHandler = (src, args) => {
          handler(src, args);
          eventInfo.RemoveEventHandler(eventSource, internalHandler);
        };
        eventInfo.AddEventHandler(eventSource, internalHandler);
      }
    }
