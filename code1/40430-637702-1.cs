    static TEntity Get<TEntity>(this DataContext ctx, int key) where TEntity : class
    {
        return Get<TEntity, int>(ctx, key);
    }
    static TEntity Get<TEntity, TKey>(this DataContext ctx, TKey key) where TEntity : class
    {
        var table = ctx.GetTable<TEntity>();
        var pkProp = (from member in ctx.Mapping.GetMetaType(typeof(TEntity)).DataMembers
                      where member.IsPrimaryKey
                      select member.Member).Single();
        ParameterExpression param = Expression.Parameter(typeof(TEntity), "x");
        Expression body = Expression.Equal(
            Expression.PropertyOrField(param, pkProp.Name),
            Expression.Constant(key, typeof(TKey)));
        var predicate = Expression.Lambda<Func<TEntity, bool>>(body, param);
        return table.Single(predicate);
    }
