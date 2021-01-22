    public static Expression<Func<T, bool>> MakeFilter<T>(string prop, object val)
    {
        ParameterExpression pe = Expression.Parameter(typeof(T), "p");
        PropertyInfo pi = typeof(T).GetProperty(prop);
        MemberExpression me = Expression.MakeMemberAccess(pe, pi);
        ConstantExpression ce = Expression.Constant(val);
        BinaryExpression be = Expression.Equal(me, ce);
        return Expression.Lambda<Func<T, bool>>(be, pe);
    }
