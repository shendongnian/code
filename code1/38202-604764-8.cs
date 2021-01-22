    private bool SomeLockingMethod(object foo)
    {
        // Verify foo is valid
        try
        {
           lock(foo)
           {
              while(something)
              {
                 // Do stuff
                 Thread.Sleep(1); // Possibly yield to another 
                                  // thread calling Thread.Interrupt
              }
           }
        
           return true;
        }
        catch(ThreadInterruptedException ex)
        {
           // Handle exception
        }
        
        return false;
    }
