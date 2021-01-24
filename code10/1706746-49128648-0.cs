                PropertyInfo propertyInfo = typeof(T).GetProperty(fieldName);
            MemberExpression m = Expression.MakeMemberAccess(e, propertyInfo);
            ConstantExpression c = Expression.Constant(comparisonValue, typeof(string));            
            MethodInfo mi = typeof(string).GetMethod(methodName, new Type[] { typeof(string) });
            Expression call = Expression.Condition(Expression.Equal(e, Expression.Constant(null)),
            Expression.NotEqual(e, Expression.Constant(null)),
            Expression.Condition(Expression.Equal(Expression.Property(e, fieldName), Expression.Constant(null)),
            Expression.NotEqual(e, Expression.Constant(null)), Expression.Call(m, mi, c)));
            return Expression.Lambda<Func<T, bool>>(call, e);
