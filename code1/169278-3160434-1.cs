    public class GpsStatusManager
    {
      public ISynchronizeInvoke SynchronizingObject { get; set; }
    
      public event EventHandler Update;
    
      public void UpdateGpsData()
      {
        // Code omitted for brevity.
        OnUpdate(_gpsStatus);
        return true;
      }
      
      private OnUpdate(GpsStatus status)
      {
        if (SynchronizingObject != null && SynchronizingObject.IsInvokeRequired)
        {
          ThreadStart ts = () => { OnUpdate(status); };
          SynchronizingObject.Invoke(ts, null);
        }
        else
        {
          if (Update != null)
          {
            Update(this, status);
          }
        }
      }
    
      public class UpdateEventArgs : EventArgs
      {
        public GpsStatus Status { get; set; }
      }
    }
