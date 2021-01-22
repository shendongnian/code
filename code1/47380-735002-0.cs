    class CachedObject<TValue> 
    { 
     DateTime Date{get;set;}
     TimeSpan Duration{get;set;}
     TValue Cached{get;set;}
    }
    class Cache : Dictionary<TKey,TValue>
    {
      public new TValue this(TKey key)
      {
        get{
        if (ContainsKey(key))
        {
           var val = base.this[key];
           //compare dates
           //if expired, remove from cache, return null
           //else return the cached item.
        }
        }
        set{//create new CachedObject, set date and timespan, set value, add to dictionary}
      }
    
