    public static class OrderExtensions {
       public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
       {
           return ApplyOrder<T>(source, property, "OrderBy");
       }
       public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
       {
           return ApplyOrder<T>(source, property, "OrderByDescending");
       }
       public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
       {
           return ApplyOrder<T>(source, property, "ThenBy");
       }
       public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T>  source, string property)
       {
           return ApplyOrder<T>(source, property, "ThenByDescending");
       }
       static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName) {
           ParameterExpression arg = Expression.Parameter(typeof(T), "x");
           Expression expr = arg;
           foreach(string prop in property.Split('.')) {
               // use reflection (not ComponentModel) to mirror LINQ
               expr = Expression.PropertyOrField(expr, prop);
           }
           Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), expr.Type);
           LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
           return (IOrderedQueryable<T>) typeof(Queryable).GetMethods().Single(
                   method => method.Name == methodName
                           && method.IsGenericMethodDefinition
                           && method.GetGenericArguments( ).Length ==2
                           && method.GetParameters().Length == 2)
                   .MakeGenericMethod(typeof(T), expr.Type)
                   .Invoke(null, new object[] {source, lambda});
      }
    }
