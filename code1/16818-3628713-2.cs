    var type = typeof(T);  
    var propertyInfo = type.GetProperty(group.PropertyName);  
    var propertyType = propertyInfo.PropertyType;  
      
    var sorterType = typeof(Func<,>).MakeGenericType(type, propertyType);  
    var expressionType = typeof(Expression<>).MakeGenericType(sorterType);  
      
    var queryType = typeof(IQueryable<T>);  
      
    var orderBy = typeof(Queryable).GetGenericMethod("OrderBy",
                                                     new Type[] { type, propertyType },
                                                     new[] { queryType, expressionType });
