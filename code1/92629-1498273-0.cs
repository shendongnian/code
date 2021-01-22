    public class SomethingReadyNotifier
    {
       private readonly Control synchronizer = new Control();
    
       /// <summary>
       /// Event raised when something is ready.
       /// The event is always raised in the message
       /// loop of the thread where this object was
       /// created.
       /// </summary>
       public event EventHandler SomethingReady;
    
       protected void OnSomethingReady()
       {
          if (SomethingReady != null)
             SomethingReady(this, EventArgs.Empty);
       }
    
       /// <summary>
       /// Causes the SomethingReady event to be raised on
       /// the message message loop of the thread which
       /// created this object.
       /// </summary>
       public void NotifySomethingReady()
       {
          this.synchronizer.BeginInvoke(new Action(OnSomethingReady));
       }
    }
