    public static T Get<T>  
        (string cacheKey, HttpContextBase context, Func<T> getItemCallback)
                where T : class
            {
                T item = Get<T>(cacheKey, context);
                if (item == null) {
                    item = getItemCallback();
                    context.Cache.Insert(cacheKey, item);
                }
    
                return item;
            }
