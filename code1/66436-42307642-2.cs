    /// <summary>
    /// Allow to search the string with wildcards.
    /// </summary>
    /// <typeparam name="T">String or an object with a string member.</typeparam>
    /// <param name="q">Original query</param>
    /// <param name="searchstring">The searchstring</param>
    /// <param name="memberName">The name of the field or null if not a field.</param>
    /// <returns>Query filtered by 'LIKE'.</returns>
    public static IQueryable<T> Like<T>(this IQueryable<T> q, string searchstring, string memberName = null)
    {
        // %a%b%c% --> IndexOf(a) > -1 && IndexOf(b) > IndexOf(a) && IndexOf(c) > IndexOf(b)
            
        var eParam = Expression.Parameter(typeof(T), "e");
            
        MethodInfo methodInfo;
        // Linq (C#) is case sensitive, but sql isn't. Use StringComparison ignorecase for Linq.
        // Sql however doesn't know StringComparison, so try to determine the provider.
        var isLinq = (q.Provider.GetType().IsGenericType && q.Provider.GetType().GetGenericTypeDefinition() == typeof(EnumerableQuery<>));
        if (isLinq)
            methodInfo = typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) });
        else
            methodInfo = typeof(string).GetMethod("IndexOf", new[] { typeof(string) });
        Expression expr;
        if (string.IsNullOrEmpty(memberName))
            expr = eParam;
        else
            expr = Expression.Property(eParam, memberName);
        // Split the searchstring by the wildcard symbol:
        var likeParts = searchstring.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < likeParts.Length; i++)
        {
            MethodCallExpression e;
            if (isLinq)
                e = Expression.Call(expr, methodInfo, new Expression[] { Expression.Constant(likeParts[i], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) });
            else
                e = Expression.Call(expr, methodInfo, Expression.Constant(likeParts[i], typeof(string)));
            if (i == 0)
            {
                // e.IndexOf("likePart") > -1
                q = q.Where(Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(e, Expression.Constant(-1, typeof(int))), eParam));
            }
            else
            {
                // e.IndexOf("likePart_previous")
                MethodCallExpression ePrevious;
                if (isLinq)
                    ePrevious = Expression.Call(expr, methodInfo, new Expression[] { Expression.Constant(likeParts[i - 1], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) });
                else
                    ePrevious = Expression.Call(expr, methodInfo, Expression.Constant(likeParts[i - 1], typeof(string)));
                // e.IndexOf("likePart_previous") < e.IndexOf("likePart")
                q = q.Where(Expression.Lambda<Func<T, bool>>(Expression.LessThan(ePrevious, e), eParam));
            }
        }
        return q;
    }
