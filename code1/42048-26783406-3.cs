    public class ThreadSafeGuiCommand
    {
      private const int SLEEPING_STEP = 100;
      private readonly int _totalTimeout;
      private int _timeout;
      public ThreadSafeGuiCommand(int totalTimeout)
      {
        _totalTimeout = totalTimeout;
      }
      public void Execute(Form form, Action guiCommand)
      {
        _timeout = _totalTimeout;
        while (!form.IsHandleCreated)
        {
          if (_timeout <= 0) return;
          Thread.Sleep(SLEEPING_STEP);
          _timeout -= SLEEPING_STEP;
        }
        if (form.InvokeRequired)
          form.Invoke(guiCommand);
        else
          guiCommand();
      }
    }
