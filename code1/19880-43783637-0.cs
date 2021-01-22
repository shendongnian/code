    public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByValues) where TEntity : class
    {
        IQueryable<TEntity> returnValue = null;
        string[] orderPairs = orderByValues.Trim().Split(',');
        Expression resultExpression = source.Expression;
        string strAsc = "OrderBy";
        string strDesc = "OrderByDescending";
        foreach (string orderPair in orderPairs)
        {
            if (string.IsNullOrWhiteSpace(orderPair))
                continue;
            string[] orderPairArr = orderPair.Trim().Split(' ');
            string propertyName = orderPairArr[0].Trim();
            string orderNarrow = orderPairArr.Length > 1 ? orderPairArr[1].Trim() : string.Empty;
            string command = orderNarrow.ToUpper().Contains("DESC") ? strDesc : strAsc;
            Type type = typeof(TEntity);
            ParameterExpression parameter = Expression.Parameter(type, "p");
            System.Reflection.PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields. 
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    Type t = property.PropertyType;
                    if (!t.IsGenericType)
                    {
                        property = t.GetProperty(childProperties[i]);
                    }
                    else
                    {
                        property = t.GetGenericArguments().First().GetProperty(childProperties[i]);
                    }
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = type.GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            if (property.PropertyType == typeof(object))
            {
                propertyAccess = Expression.Call(propertyAccess, "ToString", null);
            }
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);
            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType == typeof(object) ? typeof(string) : property.PropertyType },
                resultExpression, Expression.Quote(orderByExpression));
            strAsc = "ThenBy";
            strDesc = "ThenByDescending";
        }
        returnValue = source.Provider.CreateQuery<TEntity>(resultExpression);
        return returnValue;
    }
