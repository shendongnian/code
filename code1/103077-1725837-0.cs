    public static class ContainerExtensions{
    
    public static IDb4oLinqQuery<TObjectType> ObjectByID<TObjectType, TIdType>(this IObjectContainer db,
    Expression<Func<TObjectType, TIdType>> idPath,
    params TIdType[] ids)
    {
      if(0==ids.Length)
      {
           return db.Cast<TObjectType>().Where(o=>false);
      }
      var orCondition = BuildOrChain(ids, idPath);
      var whereClause = Expression.Lambda(orCondition, idPath.Parameters.ToArray());
      return db.Cast<TObjectType>().Where((Expression<Func<TObjectType, bool>>) whereClause);
    }
    private static BinaryExpression BuildOrChain<TIdType, TObjectType>(TIdType[] ids,     Expression<Func<TObjectType, TIdType>> idPath)
    {
      var body = idPath.Body;
      var currentExpression = Expression.Equal(body, Expression.Constant(ids.First()));
      foreach (var id in ids.Skip(1))
      {
        currentExpression = Expression.OrElse(currentExpression, Expression.Equal(body,     Expression.Constant(id)));
      }
    return currentExpression;
        }
    
    }
