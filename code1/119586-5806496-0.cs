    public class Cache
    {
       private static Cache _cache;
    
       private Cache()
       {}
    
       public Cache Instance
       {
           get
           {
              if(_cache == null)
                   _cache = new Cache();
              return _cache;
           }
       } 
       public object CachedData
       {get; set;}
    }
