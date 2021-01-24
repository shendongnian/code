    public static Action<TObject> CreateNewObjectAndSet<TObject, TProperty>(string propertyName) where TProperty: new() {
        ParameterExpression paramExpression = Expression.Parameter(typeof(TObject));
        MemberExpression propertyGetterExpression = Expression.Property(paramExpression, propertyName);
        var newObject = Expression.New(typeof(TProperty));
        var x = Expression.Assign(propertyGetterExpression, newObject);
        var paramExpressions = new ParameterExpression[1];
        paramExpressions[0] = paramExpression;
        Action<TObject> result = Expression.Lambda<Action<TObject>>(x, paramExpressions).Compile();
        return result;
    }
