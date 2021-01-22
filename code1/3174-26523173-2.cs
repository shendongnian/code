     private static readonly object _lock = new object();
    //If getOnly is true, only get existing cache value, not updating it. If cache value is null then      set it first as running action method. So could return old value or action result value.
    //If getOnly is false, update the old value with action result. If cache value is null then      set it first as running action method. So always return action result value.
    //With oldValueReturned boolean we can cast returning object(if it is not null) appropriate type on main code.
  
     public static object GetOrAdd<TResult>(this Cache cache, string key, Func<TResult> action,
        DateTime absoluteExpireTime, TimeSpan slidingExpireTime, bool getOnly, out bool oldValueReturned)
    {
        object result;
        var data = cache[key]; 
        if (data == null)
        {
            lock (_lock)
            {
                data = cache[key];
                if (data == null)
                {
                    oldValueReturned = false;
                    result = action();
                    if (result == null)
                    {                       
                        return result;
                    }
                    cache.Insert(key, result, null, absoluteExpireTime, slidingExpireTime);
                }
                else
                {
                    if (getOnly)
                    {
                        oldValueReturned = true;
                        result = data;
                    }
                    else
                    {
                        oldValueReturned = false;
                        result = action();
                        if (result == null)
                        {
                            oldValueReturned = false;
                            return result;
                        }
                        cache.Insert(key, result, null, absoluteExpireTime, slidingExpireTime);
                    }
                }
            }
        }
        else
        {
            if(getOnly)
            {
                oldValueReturned = true;
                result = data;
            }
            else
            {
                oldValueReturned = false;
                result = action();
                if (result == null)
                {
                    return result;
                }
                cache.Insert(key, result, null, absoluteExpireTime, slidingExpireTime);
            }            
        }
        return result;
    }
