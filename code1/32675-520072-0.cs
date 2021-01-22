    /// <summary>
    /// Invokes the specified <paramref name="action"/> on the thread that owns     
    /// the <paramref name="control"/>.</summary>
    /// <typeparam name="TControl">type of the control to work with</typeparam>
    /// <param name="control">The control to execute action against.</param>
    /// <param name="action">The action to on the thread of the control.</param>
    public static void Invoke<TControl>(this TControl control, Action action) 
      where TControl : Control
    {
      if (!control.InvokeRequired)
      {
        action();
      }
      else
      {
        control.Invoke(action);
      }
    }
