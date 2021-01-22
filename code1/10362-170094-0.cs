    public bool TryEnter(object lockObject, Action work) 
    {
        if (Monitor.TryEnter(lockObject)) 
        {
           try 
           {
              work();
           }
           finally 
           {
               Monitor.Exit(lockObject);
           }        
           return true;
         }
         return false;
    }
