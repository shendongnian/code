    public class UpdateCache
    {
       private static object _myLockObject;
    
       public static void UpdateCache()
       {
         lock(_myLockObject)
         {
            .. Update cache object
         }
       }
    
       public static void LoadFromCache(string key)
       {
         lock(_myLockObject)
         {
           .. retrieve data from cache
         }   
    
       }
    } 
