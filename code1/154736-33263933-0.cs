    // returns property getter
    public static Func<TObject, TProperty> GetPropGetter<TObject, TProperty>(string propertyName)
    {
        ParameterExpression paramExpression = Expression.Parameter(typeof(TObject), "value");
    
        Expression propertyGetterExpression = Expression.Property(paramExpression, propertyName);
    
        Func<TObject, TProperty> result =
            Expression.Lambda<Func<TObject, TProperty>>(propertyGetterExpression, paramExpression).Compile();
    
        return result;
    }
    
    // returns property setter:
    public static Action<TObject, TProperty> GetPropSetter<TObject, TProperty>(string propertyName)
    {            
        ParameterExpression paramExpression = Expression.Parameter(typeof(TObject));
    
        ParameterExpression paramExpression2 = Expression.Parameter(typeof(TProperty), propertyName);
    
        MemberExpression propertyGetterExpression = Expression.Property(paramExpression, propertyName);
    
        Action<TObject, TProperty> result = Expression.Lambda<Action<TObject, TProperty>>
        (
            Expression.Assign(propertyGetterExpression, paramExpression2), paramExpression, paramExpression2
        ).Compile();
    
        return result;
    }
