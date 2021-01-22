    using System.ComponentModel;
    public static class ISynchronizeInvokeExtensions
    {
      public static void InvokeEx<T>(this T @this, Action<T> action, bool synchronous)
        where T : ISynchronizeInvoke
      {
        if (@this == null)
          throw new ArgumentNullException("@this");
    
        if (!@this.IsHandleCreated)
          return;
    
        if (@this.IsDisposed)
          throw new ObjectDisposedException("@this is already disposed.");
    
        if (@this.InvokeRequired)
        {
          if (synchronous)
            @this.Invoke(action, new object[] { @this });
          else
            @this.BeginInvoke(action, new object[] { @this });
        }
        else
        {
          action(@this);
        }
      }
    }
