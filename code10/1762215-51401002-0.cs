    public static IQueryable<TResult> Select<TSource, TResult>(this IQueryable<TSource> source, IEnumerable<string> columns)
    {
        // the x in x => ...
        var par = Expression.Parameter(typeof(TSource), "x");
        // "Bindings" (the Col1 = x.Col1 inside the x => new { Col1 = x.Col1 })
        var binds = columns.Select(x => Expression.Bind((MemberInfo)typeof(TResult).GetProperty(x) ?? typeof(TResult).GetField(x), Expression.PropertyOrField(par, x)));
        // new TResult
        var new1 = Expression.New(typeof(TResult));
        // new TResult { Bindings }
        var mi = Expression.MemberInit(new1, binds);
        // x => new TResult { Bindings }
        var lambda = Expression.Lambda<Func<TSource, TResult>>(mi, par);
        // Select(x => new TResult { Bindings })
        return source.Select(lambda);
    }
