    public class SomethingReadyNotifier
    {
       private readonly Control synchronizer = new Control();
    
       /// <summary>
       /// Event raised when something is ready. The event is always raised in the
       /// message loop of the thread where this object was created.
       /// </summary>
       public event EventHandler SomethingReady;
    
       protected void OnSomethingReady()
       {
          // Use this technique to avoid potential race condition.
          EventHandler handler = SomethingReady;
          if (handler != null)
             handler(this, EventArgs.Empty);
       }
    
       /// <summary>
       /// Causes the SomethingReady event to be raised on the message loop of the
       /// thread which created this object.
       /// </summary>
       /// <remarks>
       /// Can safely be called from any thread. Always returns immediately without
       /// waiting for the event to be handled.
       /// </remarks>
       public void NotifySomethingReady()
       {
          this.synchronizer.BeginInvoke(new Action(OnSomethingReady));
       }
    }
