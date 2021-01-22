    public static IList<T> GetList<T>(
        this DataContext context, bool activeOnly )
        where T : class
    {
        IQueryable<T> query = context.GetTable<T>();
        var param = Expression.Parameter(typeof(T), "row");
        if(activeOnly)
        {
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(param, "IsActive"),
                    Expression.Constant(true,typeof(bool))
                ), param);
            query = query.Where(predicate);
        }
        var selector = Expression.Lambda<Func<T, string>>(
            Expression.PropertyOrField(param, "Title"), param);
        return query.OrderBy(selector).ToList();
    }
