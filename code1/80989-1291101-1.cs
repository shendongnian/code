    AutoResetEvent e = new AutoResetEvent(false);
    AutoResetEvent readyForMore = new AutoResetEvent(true); // Initially signaled
    public SetData(MyData d)
    {
       // This will immediately determine if readyForMore is set or not.
       if( readyForMore.WaitOne(0,true) ) {
         this.d=d;
         e.Set();    // notify that new data is available
      }
      // you could return a bool or something to indicate it bailed.
    }
    
    void Runner() // this runs in separate thread and waits for d to be set to a new value
    {
    
         while (true)
         {
                 
                 e.WaitOne();  // waits for new data to process
                 DoLongOperationWith_d(d);
                 readyForMore.Set();
         }
    }
