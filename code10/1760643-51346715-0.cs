     var dbSet = DbContext.Set<T>();
        
        var properties = typeof(T)
                         .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         .Where(p=> p.SetMethod !=null);
        
        var queryable = default(IQueryable<T>);
        properties.ForEach(p => { queryable = (queryable ?? dbSet).Include(p.Name); });
                    
        return queryable;
