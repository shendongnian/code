    public static TEntity Get<TEntity>(this DataContext dataContext, int id)
            where TEntity : class
    {
        return Get<TEntity, int>(dataContext, id);
    }
    public static TEntity Get<TEntity, TKey>(this DataContext dataContext, TKey id)
        where TEntity : class
    {
        // get the row from the database using the meta-model
        MetaType meta = dataContext.Mapping.GetTable(typeof(TEntity)).RowType;
        if (meta.IdentityMembers.Count != 1) throw new InvalidOperationException(
            "Composite identity not supported");
        string idName = meta.IdentityMembers[0].Member.Name;
        var param = Expression.Parameter(typeof(TEntity), "row");
        var lambda = Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.PropertyOrField(param, idName),
                Expression.Constant(id, typeof(TKey))), param);
        return dataContext.GetTable<TEntity>().Single(lambda);
    }
