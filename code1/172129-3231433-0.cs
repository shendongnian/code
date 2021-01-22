    public static IQueryable<TEntity> WhereActive<TEntity>(
        this IQueryable<TEntity> entities)
        where TEntity : class , Database.IHideable
    {
        var allowedStates = new string[] { "Active", "Pending" };
        return (
            from entity in entities
            where allowedStates.Contains(entity.State)
                && entity.Hidden == "No"
            select entity
        );
    }  
