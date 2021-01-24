    public sealed class theDDEServer : DdeServer
    {
      DDEServer_MainForm mainForm;
      System.Timers.Timer _Timer = new System.Timers.Timer();
    
      public theDDEServer(string service, Form mainForm) : base(service)
      {
        DDEServer_MainForm = mainForm;
        _Timer.Elapsed += this.OnTimerElapsed;
        _Timer.Interval = 1000;
        _Timer.SynchronizingObject = this.Context;
      }
    
      /* snipped out code */
    
      public override void Unregister()
      {
        DDEServer_MainForm =  null;
        _Timer.Stop();
        base.Unregister();
      }
    
      /* snipped out code */
    
    }
