    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Something
    {
      public static class TimeoutWrapper
      {
        public static void Invoke(TimeSpan timeout, Action action)
        {
          Invoke(timeout, action, null);
        }
        public static void Invoke(TimeSpan timeout, Action action, Action abort)
        {
          Thread threadToKill = null;
          Action wrappedAction = () =>
          {
            threadToKill = Thread.CurrentThread;
            action();
          };
    
          IAsyncResult result = wrappedAction.BeginInvoke(null, null);
          if (result.AsyncWaitHandle.WaitOne(timeout, true))
          {
            wrappedAction.EndInvoke(result);
          }
          else
          {
            if (threadToKill != null)
            {
              try { threadToKill.Abort(); }
              catch { /* Ignore */ }
            }
    
            if (abort != null)
              abort();
    
            throw new TimeoutException();
          }
        }
      }
    }
