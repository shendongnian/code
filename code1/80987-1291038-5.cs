    object sync = new object(); 
    AutoResetEvent e = new AutoResetEvent(false);
    bool pending = false; 
    
    public SetData(MyData d)
    {
       lock(sync) 
       {
          if (pending) throw(new CanNotSetDataException()); 
    
          this.d=d;
          pending = true;
       }
          
       e.Set();    // notify that new data is available
    }
    
    void Runner() // this runs in separate thread and waits for d to be set to a new value
    {
    
         while (true)
         {
    
                 e.WaitOne();  // waits for new data to process
                 DoLongOperationWith_d(d);
                 lock(sync) 
                 {
                    pending = false; 
                 }
         }
    }
