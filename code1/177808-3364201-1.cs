    public partial class MainShell : UserControl, IAppGlobalState 
    {
       private int _queue; 
       private object _mutex = new Object();
    
       public void BeginASync()
       {
          Monitor.Enter(_mutex);
          if (_queue++ == 0)
          {
             VisualStateManager.GoToState(this, "BusyState", true);
          }
          Monitor.Exit(_mutex);
       }
    
       public void EndAsync()
       {
          Monitor.Enter(_mutex);
          if (--_queue == 0)
          {
             VisualStateManager.GoToState(this, "IdleState", true); 
          }
          Monitor.Exit(_mutex);
       }
    }
