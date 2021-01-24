    public void Invoke(Action callback, DispatcherPriority priority, CancellationToken cancellationToken, TimeSpan timeout)
    {
       if(callback == null)
       {
          throw new ArgumentNullException("callback");
       }
       ValidatePriority(priority, "priority");
    
       if( timeout.TotalMilliseconds < 0 &&
           timeout != TimeSpan.FromMilliseconds(-1))
       {
          throw new ArgumentOutOfRangeException("timeout");
       }
    
       // Fast-Path: if on the same thread, and invoking at Send priority,
       // and the cancellation token is not already canceled, then just
       // call the callback directly.
       if(!cancellationToken.IsCancellationRequested && priority == DispatcherPriority.Send && CheckAccess())
