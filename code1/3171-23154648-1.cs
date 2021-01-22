    private static readonly object _lock = new object();
    
    public static TResult GetOrAdd<TResult>(this Cache cache, string key, Func<TResult> action, int duration = 300) {
        TResult result;
        var data = cache[key]; // Can't cast using as operator as TResult may be an int or bool
    
        if (data == null) {
            lock (_lock) {
                data = cache[key];
    
                if (data == null) {
                    result = action();
    
                    if (result == null)
                        return result;
    
                    if (duration > 0)
                        cache.Insert(key, result, null, DateTime.UtcNow.AddSeconds(duration), TimeSpan.Zero);
                } else
                    result = (TResult)data;
            }
        } else
            result = (TResult)data;
    
        return result;
    }
