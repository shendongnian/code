    public class LoopingThread
    {
      private readonly Action _loopedAction;
      private readonly AutoResetEvent _pauseEvent;
      private readonly AutoResetEvent _resumeEvent;
      private readonly AutoResetEvent _stopEvent;
      private readonly AutoResetEvent _waitEvent;
      private readonly Thread _thread;
      public LoopingThread (Action loopedAction)
      {
        _loopedAction = loopedAction;
        _thread = new Thread (Loop);
        _pauseEvent = new AutoResetEvent (false);
        _resumeEvent = new AutoResetEvent (false);
        _stopEvent = new AutoResetEvent (false);
        _waitEvent = new AutoResetEvent (false);
      }
      public void Start ()
      {
        _thread.Start();
      }
      public void Pause (int timeout = 0)
      {
        _pauseEvent.Set();
        _waitEvent.WaitOne (timeout);
      }
      public void Resume ()
      {
        _resumeEvent.Set ();
      }
      public void Stop (int timeout = 0)
      {
        _stopEvent.Set();
        _resumeEvent.Set();
        _thread.Join (timeout);
      }
      public void WaitForPause ()
      {
        Pause (Timeout.Infinite);
      }
      public void WaitForStop ()
      {
        Stop (Timeout.Infinite);
      }
      public int PauseBetween { get; set; }
      private void Loop ()
      {
        do
        {
          _loopedAction ();
          if (_pauseEvent.WaitOne (PauseBetween))
          {
            _waitEvent.Set ();
            _resumeEvent.WaitOne (Timeout.Infinite);
          }
        } while (!_stopEvent.WaitOne (0));
      }
    }
