    using System.Linq.Expressions;
    ...
    
    
    IQueryable<T> query = someQuery;
    Expression expression = query.Expression;
    
    ParameterExpression obj = Expression.Parameter(query.ElementType, "obj");
    MemberExpression property = Expression.PropertyOrField(obj, propertyName);
    Expression<Func<T,bool>> lambda = Expression.Lambda<Func<T,bool>>(property, obj);
    query = query.Where(lambda);
