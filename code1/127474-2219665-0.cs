    Cache.Insert("MyText", someTextVariable, null, DateTime.Now.AddSeconds(10), 
                 TimeSpan.Zero, CacheItemPriority.High, 
                 new CacheItemRemovedCallback(ItemRemoved))
    
    
    public void ItemRemoved(string key, object value, CacheItemRemovedReason reason)
    {
        // write value to file
    }
