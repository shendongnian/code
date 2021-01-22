      public static class ActionExtensions
      {
        private static readonly ILog log = LogManager.GetLogger(typeof(ActionExtensions));
    
        /// <summary>
        /// Async exec action.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void AsyncInvokeHandlers(
          this Action action)
        {
          if (action == null)
          {
            return;
          }
    
          foreach (Action handler in action.GetInvocationList())
          {
            // Initiate the asychronous call.  Include an AsyncCallback
            // delegate representing the callback method, and the data
            // needed to call EndInvoke.
            handler.BeginInvoke(
              ar =>
              {
                try
                {
                  // Retrieve the delegate.
                  var handlerToFinalize = (Action)ar.AsyncState;
                  // Call EndInvoke to free resources.
                  handlerToFinalize.EndInvoke(ar);
    
                  var handle = ar.AsyncWaitHandle;
                  if (handle.SafeWaitHandle != null && !handle.SafeWaitHandle.IsInvalid && !handle.SafeWaitHandle.IsClosed)
                  {
                    ((IDisposable)handle).Dispose();
                  }
                }
                catch (Exception exception)
                {
                  log.Error("Async Action exec error.", exception);
                }
              },
              handler);
          }
        }
      }
