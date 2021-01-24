    public static IQueryable<testItem> PropertyContainsNEW(this IQueryable<testItem> source,
            Expression<Func<testItem, string>> selector,
            string value)
    {
       var parameter = Expression.Parameter(typeof(testItem), "x");
       var property = Expression.Property(parameter, ((MemberExpression)selector.Body).Member.Name);
       var search = Expression.Constant(value, typeof(string));
       var parms = new Expression[] { search,
                Expression.Constant(StringComparison.OrdinalIgnoreCase) };
       var method = typeof(string).GetMethod("Contains", new[] { typeof(string), typeof(StringComparison) });
       var containsMethodExp = Expression.Call(property, method, parms);
       var predicate = Expression.Lambda<Func<testItem, bool>>(containsMethodExp, parameter);
       return source.Where(predicate);
    }
