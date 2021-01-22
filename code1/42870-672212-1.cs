    public PropertyInfo GetPropertyInfo<TSource, TProperty>(
        TSource source,
        Expression<Func<TSource, TProperty>> propertyLambda)
    {
        if (!(propertyLambda is MemberExpression member))
            throw new ArgumentException(
              $"Expression '{propertyLambda}' refers to a method, not a property.");
        if (!(member.Member is PropertyInfo propInfo))
            throw new ArgumentException(
              $"Expression '{propertyLambda}' refers to a field, not a property.");
        var type = typeof(TSource);
        if (!type.IsAssignableFrom(propInfo.DeclaringType))
            throw new ArgumentException(
              $"Expresion '{propertyLambda}' refers to a property that is not " +
              "from type '{type}'.");
        return propInfo;
    }
