    private static LambdaExpression GenerateSelector<TEntity>(String propertyName, out Type resultType) where TEntity : class
    {
        // Create a parameter to pass into the Lambda expression (Entity => Entity.OrderByField).
        var parameter = Expression.Parameter(typeof(TEntity), "Entity");
        //  create the selector part, but support child properties
        PropertyInfo property;
        Expression propertyAccess;
        if (propertyName.Contains('.'))
        {
                // support to be sorted on child fields.
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                        property = property.PropertyType.GetProperty(childProperties[i]);
                        propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
        }
        else
        {
                property = typeof(TEntity).GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
        }
        resultType = property.PropertyType;                     
        // Create the order by expression.
        return Expression.Lambda(propertyAccess, parameter);
    }
    private static MethodCallExpression GenerateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, String fieldName) where TEntity : class
    {
        Type type = typeof(TEntity);
        Type selectorResultType;
        LambdaExpression selector = GenerateSelector<TEntity>(fieldName, out selectorResultType);
        MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
                                        new Type[] { type, selectorResultType },
                                        source.Expression, Expression.Quote(selector));
        return resultExp;
    }
