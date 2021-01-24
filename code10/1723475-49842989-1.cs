    public static IOrderedQueryable<int> OrderById(Type entityType)
    {
        var dbSet = context.Set(entityType);
        var item = Expression.Parameter(entityType, "item");
        var property = Expression.Property(item, "Id");
        var lambda = Expression.Lambda<Func<T, int>>(property, item);
        // the above generates:
        // item => item.Id
        return dbSet.OrderByDescending(lambda);
    }
