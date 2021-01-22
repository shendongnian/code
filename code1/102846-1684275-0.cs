    class bar
    {
      private int foo;
      private System.Threading.Mutex lock = new System.Threading.Mutex;
    
      public void proc1()
      {
        lock.WaitOne();
        
        // do stuff to foo
    
        lock.ReleaseMutex();
      }
    
      public void proc2()
      {
        lock.WaitOne();
        
        // do stuff to foo
    
        lock.ReleaseMutex();
      }
    };
