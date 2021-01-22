    public static class FormHelpers
    {
      public static void InvokeOnActive<TForm>(Action<TForm> action)
        where TForm : Form
      {
        TForm activeForm = Form.ActiveForm as TForm;
        if (activeForm != null)
          activeForm.InvokeEx(f => { action(f); return f; });
      }
    }
    
    public static class ControlExtensions
    {
      public static TResult InvokeEx<TControl, TResult>(this TControl control,
                                                  Func<TControl, TResult> func)
        where TControl : Control
      {
        if (control.InvokeRequired)
          return (TResult)control.Invoke(func, control);
        else
          return func(control);
      }
    }
