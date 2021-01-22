    public static class ControlExtensions
    {
      public static TResult InvokeEx<TControl, TResult>(this TControl control,
                                Func<TControl, TResult> func)
        where TControl : Control
      {
        if (control.InvokeRequired)
        {
          return (TResult)control.Invoke(func, control);
        }
        else
        {
          return func(control);
        }
      }
    }
