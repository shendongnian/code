    static TEntity Get<TEntity, TKey>(this DataContext ctx, TKey key) where TEntity : class
    {
        var table = ctx.GetTable<TEntity>();
        var pkProp = (from prop in typeof (TEntity).GetProperties()
                      let attrib = Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute)) as ColumnAttribute
                      where attrib != null && attrib.IsPrimaryKey
                      select prop).Single();
        ParameterExpression param = Expression.Parameter(typeof (TEntity), "x");
        Expression body = Expression.Equal(
            Expression.Property(param, pkProp),
            Expression.Constant(key, typeof (TKey)));
        var predicate = Expression.Lambda<Func<TEntity, bool>>(body, param);
        return table.Single(predicate);
    }
