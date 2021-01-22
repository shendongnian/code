    public class SingletonCacheService : IGraphDataCacheService {
       private static Singleton instance;
    
       private Singleton() {}
    
       // snip implementation of IGraphDataCacheService methods ...
    
       public static Singleton Instance {
          get {
             if (instance == null) {
                instance = new Singleton();
             }
             return instance;
          }
       }
    }
