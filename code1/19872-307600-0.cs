            var type = typeof(T);  
            var property = type.GetProperty(columnName);  
            var parameter = Expression.Parameter(type, "p");  
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);  
            var orderByExp = Expression.Lambda(propertyAccess, parameter);  
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, currentItems.Expression, Expression.Quote(orderByExp));
