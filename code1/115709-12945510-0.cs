    public sealed class Singleton
    {
       private static Singleton instance;
       private static object syncRoot = new Object();
    
       private Singleton() {}
    
       public static Singleton Instance
       {
          get 
          {
             // very fast test, without implicit memory barriers or locks
             if (instance == null)
             {
                lock (syncRoot)
                {
                   if (instance == null)
                   {
                        var temp = new Singleton();
                        // ensures that the instance is well initialized,
                        // and only then, it assigns the static variable.
                        System.Threading.Thread.MemoryBarrier();
                        instance = temp;
                   }
                }
             }
    
             return instance;
          }
       }
    }
