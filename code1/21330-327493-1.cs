    class ServiceClass
    {
         private object thisLock = new object();
        
         public Method1()
         {
            lock ( thisLock )
            {
                 ...
            }
         }
         public Method2()
         {
            lock ( thisLock )
            {
                 ...
            }
         }
         ...
    }
