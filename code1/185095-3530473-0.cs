    public static Expression<Func<T1, TResult>> Bind2nd<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> source, T2 argument)
    {
            Expression arg2 = Expression.Constant(argument, typeof(T2));
            var arg1 = Expression.Parameter(typeof(T1));
            return Expression.Lambda<Func<T1, TResult>>(Expression.Invoke(source, arg1, arg2), arg1);
    }
