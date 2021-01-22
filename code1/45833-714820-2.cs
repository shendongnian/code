    public static class ControlExtensions
    {
      public static void InvokeEx<T>(this T @this, Action<T> action)
        where T : Control
      {
        if (@this.InvokeRequired)
        {
          @this.Invoke(action, new object[] { @this });
        }
        else
        {
          if (!@this.IsHandleCreated)
            return;
          if (@this.IsDisposed)
            throw new ObjectDisposedException("@this is disposed.");
    
          action(@this);
        }
      }
    
      public static IAsyncResult BeginInvokeEx<T>(this T @this, Action<T> action)
        where T : Control
      {
        return @this.BeginInvoke((Action)delegate { @this.InvokeEx(action); });
      }
    
      public static void EndInvokeEx<T>(this T @this, IAsyncResult result)
        where T : Control
      {
        @this.EndInvoke(result);
      }
    }
