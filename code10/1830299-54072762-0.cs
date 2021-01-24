    public static Expression<Func<T, bool>> ContainsPredicate<T>(string columnName, object searchValue)
    {
        var type = typeof(T);
        var x = Expression.Parameter(type, "x");
        var member = Expression.Property(x, columnName);
        ConstantExpression constant;
        // Contains
        if (member.Type == typeof(int))
        {
            MethodInfo toStringMethod = typeof(object).GetMethod("ToString");
                
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            constant = Expression.Constant(searchValue.ToString());
            var call = Expression.Call(Expression.Call(member, toStringMethod), method, constant);
            return Expression.Lambda<Func<T, bool>>(call, x);
        }
        else
        {
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            constant = Expression.Constant(searchValue, typeof(string));
            var call = Expression.Call(member, method, constant);
            return Expression.Lambda<Func<T, bool>>(call, x);
        }
    }
