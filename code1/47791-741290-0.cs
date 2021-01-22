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
    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
      }
    
      Thread guiUpdateThread = null;
      public void BeginLongGuiUpdate(MyState state)
      {
        if (guiUpdateThread != null && guiUpdateThread.ThreadState != ThreadState.Stopped)
        {
          guiUpdateThread.Abort();
          guiUpdateThread.Join(); // wait for thread to abort
        }
    
        guiUpdateThread = new Thread(LongGuiUpdate);
        guiUpdateThread.Start(state);
      }
    
      private void LongGuiUpdate(object state)
      {
        MyState myState = state as MyState;
        // ...
        Thread.Sleep(200);
        this.InvokeEx(f => f.Text = myState.NewTitle);
        // ...
      }
    }
