    public sealed class Singleton
    {
       private static volatile Singleton instance;
       private static object syncRoot = new object();
    
       private Singleton()
       {
          // any code that needs to run to create a valid instance of the object.
       }
    
       public static Singleton Instance
       {
          get
          {
             if (instance == null)
             {
                lock(syncRoot)
                {
                   if (instance == null)
                   {
                      instance = new Singleton();
                   }
                }
             }
    
             return instance;
          }
       }
    }
