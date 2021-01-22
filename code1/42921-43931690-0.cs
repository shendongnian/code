    PropertyInfo GetPropertyName<TSource, TProperty>(
    Expression<Func<TSource, TProperty>> propertyLambda)
    {
      var body = propertyLambda.Body;
      if (!(body is MemberExpression member)
        && !(body is UnaryExpression unary
          && (member = unary.Operand as MemberExpression) != null))
        throw new ArgumentException($"Expression '{propertyLambda}' " +
          "refers to a method, not a property.");
      if (!(member.Member is PropertyInfo propInfo))
        throw new ArgumentException($"Expression '{propertyLambda}' " +
          "refers to a field, not a property.");
      var type = typeof(TSource);
      if (!propInfo.DeclaringType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
        throw new ArgumentException($"Expresion '{propertyLambda}' " + 
          "refers to a property that is not from type '{type}'.");
      return propInfo;
    }
