    public static Func<TFirst, TSecond, TFirst> MappingDynamicFunc<TFirst, TSecond>()
    {
        ParameterExpression paramFirst = Expression.Parameter(typeof(TFirst), "paramFirst");
        ParameterExpression paramSecond = Expression.Parameter(typeof(TSecond), "paramSecond");
    
        MemberExpression memberExpression = Expression.PropertyOrField(paramFirst, "UserCreatedPage");
        BinaryExpression assign = Expression.Assign(memberExpression, paramSecond);
    
        LabelTarget labelTarget = Expression.Label(typeof(TFirst));
        GotoExpression returnExpression = Expression.Return(labelTarget, paramFirst, typeof(TFirst));
        LabelExpression labelExpression = Expression.Label(labelTarget, Expression.Default(typeof(TFirst)));
    
        BlockExpression block = Expression.Block(
            assign,
            returnExpression,
            labelExpression
        );
    
        return Expression.Lambda<Func<TFirst, TSecond, TFirst>>(block, new ParameterExpression[] { paramFirst, paramSecond }).Compile();
    }
