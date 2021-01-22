    /// <summary>
    /// Get metadata of property referenced by expression. Type constrained.
    /// </summary>
    public static PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
    {
        return GetPropertyInfo((LambdaExpression) propertyLambda);
    }
    /// <summary>
    /// Get metadata of property referenced by expression.
    /// </summary>
    public static PropertyInfo GetPropertyInfo(LambdaExpression propertyLambda)
    {
        // https://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
        MemberExpression member = propertyLambda.Body as MemberExpression;
        if (member == null)
            throw new ArgumentException(string.Format(
                "Expression '{0}' refers to a method, not a property.",
                propertyLambda.ToString()));
    
        PropertyInfo propInfo = member.Member as PropertyInfo;
        if (propInfo == null)
            throw new ArgumentException(string.Format(
                "Expression '{0}' refers to a field, not a property.",
                propertyLambda.ToString()));
    
        if(propertyLambda.Parameters.Count() == 0)
            throw new ArgumentException(String.Format(
                "Expression '{0}' does not have any parameters. A property expression needs to have at least 1 parameter.",
                propertyLambda.ToString()));
    
        var type = propertyLambda.Parameters[0].Type;
        if (type != propInfo.ReflectedType &&
            !type.IsSubclassOf(propInfo.ReflectedType))
            throw new ArgumentException(String.Format(
                "Expression '{0}' refers to a property that is not from type {1}.",
                propertyLambda.ToString(),
                type));
        return propInfo;
    }
