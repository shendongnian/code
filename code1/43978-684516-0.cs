    // Somewhere else in the code
    using System;
    using System.Threading;
    
    // In the class or whever appropriate
    static AutoResetEvent autoEvent = new AutoResetEvent(false);
    void MyWorkerThread()
    {
       while(1)
       {
         // Wait for work method to signal.
            if(autoEvent.WaitOne(30000, false))
            {
                // Signalled time to quit
                return;
            }
            else
            {
                // grab a lock
                // do the work
                // Whatever...
            }
       }
    }
