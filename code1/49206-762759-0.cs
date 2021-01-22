    public static class ControlExtensions
    {
      public static TResult InvokeEx<TControl, TResult>(this TControl control,
                                              Func<TControl, TResult> func)
        where TControl : Control
      {
        if (!control.IsHandleCreated)
          return default(T);
        
        if (control.InvokeRequired)
          return (TResult)control.Invoke(func, control);
        else
          return func(control);
      }
      
      public static void InvokeEx<TControl>(this TControl control,
                                            Action<TControl> action)
        where TControl : Control
      {
        control.InvokeEx(c => { action(c); return c; });
      }
    }
