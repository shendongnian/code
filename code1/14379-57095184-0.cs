      public static class EventHandlerExtensions
      {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    
        public static void RaiseEventSafely(this EventHandler theEvent, object sender, EventArgs args)
        {
          if (theEvent == null)
            return;
    
          foreach (EventHandler handler in theEvent.GetInvocationList())
          {
            Task.Run(() =>
            {
              try
              {
                handler(sender, args);
              }
              catch (Exception ex)
              {
                _log.Error(ex);
              }
            });
          }
        }
    
        public static void RaiseEventSafely<T>(this EventHandler<T> theEvent, object sender, T args)
        {
          if (theEvent == null)
            return;
    
          foreach (EventHandler<T> handler in theEvent.GetInvocationList())
          {
            Task.Run(() =>
            {
              try
              {
                handler(sender, args);
              }
              catch (Exception ex)
              {
                _log.Error(ex);
              }
            });
          }
        }
      }
