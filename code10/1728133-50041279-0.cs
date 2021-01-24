    public static IQueryable<T> IncludeOnly<T>(this IQueryable<T> query, params string[] properties) {
        var arg = Expression.Parameter(typeof(T), "x");
        var bindings = new List<MemberBinding>();
        foreach (var propName in properties) {
            var prop = typeof(T).GetProperty(propName);
            bindings.Add(Expression.Bind(prop, Expression.Property(arg, prop)));
        }
        // our select, x => new T {Prop1 = x.Prop1, Prop2 = x.Prop2 ...}
        var select = Expression.Lambda<Func<T, T>>(Expression.MemberInit(Expression.New(typeof(T)), bindings), arg);
        return query.Select(select);
    }
