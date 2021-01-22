      public static class EventHandlerExtensions
      {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    
        public static void Taskify(this EventHandler theEvent, object sender, EventArgs args)
        {
          Invoke(theEvent, sender, args, true);
        }
    
        public static void Taskify<T>(this EventHandler<T> theEvent, object sender, T args)
        {
          Invoke(theEvent, sender, args, true);
        }
    
        public static void InvokeSafely(this EventHandler theEvent, object sender, EventArgs args)
        {
          Invoke(theEvent, sender, args, false);
        }
    
        public static void InvokeSafely<T>(this EventHandler<T> theEvent, object sender, T args)
        {
          Invoke(theEvent, sender, args, false);
        }
    
        private static void Invoke(this EventHandler theEvent, object sender, EventArgs args, bool taskify)
        {
          if (theEvent == null)
            return;
    
          foreach (EventHandler handler in theEvent.GetInvocationList())
          {
            var action = new Action(() =>
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
    
            if (taskify)
              Task.Run(action);
            else
              action();
          }
        }
    
        private static void Invoke<T>(this EventHandler<T> theEvent, object sender, T args, bool taskify)
        {
          if (theEvent == null)
            return;
    
          foreach (EventHandler<T> handler in theEvent.GetInvocationList())
          {
            var action = new Action(() =>
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
    
            if (taskify)
              Task.Run(action);
            else
              action();
          }
        }
      }
