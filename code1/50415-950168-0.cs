    public static void ExecuteAsync<TControl>(this TControl control, Action action)
    where TControl : Control
    {
      new Thread(() =>
      {
        control.Invoke(action);
      })
      .Start();
    }
