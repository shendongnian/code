    MyObject myObject = null;
    if(!Cache.TryGetItemFromCache(out myObject)){
         //get data
         Cache.AddToCache<MyObject>(data);
    }
    and..
    
    Cache.Remove<MyObject>();
