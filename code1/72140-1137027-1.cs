    public void DoWork()
    {
       try
       {  
          while(!cancelThreads)
          {
             // Do general work
    
             Thread.BeginCriticalRegion();
               // Do Important Work
             Thread.EndCriticalRegion(); 
          }
        }
        catch(ThreadAbortException)
        {
          // Tidy any nastiness that occured killing thread early    
        }
    }
