    public static ObjectQuery<T> Include<T>(this ObjectQuery<T> mainQuery, Expression<Func<T, object>> tSubSelector, params Expression<Func<object, object>>[] subSelectors)
    {
        var pathBuilder = new StringBuilder(((PropertyInfo)((MemberExpression)tSubSelector.Body).Member).Name);
        foreach (var selector in subSelectors)
        {
            pathBuilder.Append('.');
            pathBuilder.Append(((PropertyInfo)((MemberExpression)selector.Body).Member).Name);
        }
        return mainQuery.Include(pathBuilder.ToString());
    }
