    AutoResetEvent e = new AutoResetEvent(false);
    AutoResetEvent readyForMore = new AutoResetEvent(true); // Initially signaled
    public SetData(MyData d)
    {
       readyForMore.WaitOne();
       this.d=d;
       e.Set();    // notify that new data is available
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
