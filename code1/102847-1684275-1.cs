    class bar
    {
      private System.Threading.ManualResetEvent event = new System.Threading.ManualResetEvent;
    
      public void proc1()
      {
        // do stuff
    
        event.Set();
      }
    
      public void proc2()
      {
        event.WaitOne();
        event.Reset();
        
        // do stuff
      }
    };
