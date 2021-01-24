    var itemType = list.First().GetType();
    var propertyName = "SomeProperty";
    var parameterExpr = Expression.Parameter(typeof(IDynamicGeneratedModelClass));
    var castExpr = Expression.Convert(parameterExpr, itemType);
    var propExpr = Expression.Property(castExpr, propertyName);
    var lambdaExpr = Expression.Lambda(propExpr, parameterExpr);
    // Compiled lambda is now of type Func<IDynamicGeneratedModelClass, object>
    Func<IDynamicGeneratedModelClass, object> compiledLambdaFunction = (Func<IDynamicGeneratedModelClass, object>)lambdaExpr.Compile();
    var result = list.GroupBy(compiledLambdaFunction);
