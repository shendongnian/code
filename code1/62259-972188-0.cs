     public class Monitor
     {
         private Hashtable Master; //key=device, value=list of settings to watch
         ...
         private object tableLock = new object();
         public void register(watchlist) 
         {
             lock(tableLock) {
                 // do stuff
             }
         }
     }
