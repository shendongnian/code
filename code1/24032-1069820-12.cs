    public static IQueryable<TEntity> WhereIn<TEntity, TValue>
      (
        this ObjectQuery<TEntity> query,
        Expression<Func<TEntity, TValue>> selector,
        IEnumerable<TValue> collection
      )
    {
      if (selector == null) throw new ArgumentNullException("selector");
      if (collection == null) throw new ArgumentNullException("collection");
      if (!collection.Any()) 
        return query.Where(t => false);
      ParameterExpression p = selector.Parameters.Single();
      IEnumerable<Expression> equals = collection.Select(value =>
         (Expression)Expression.Equal(selector.Body,
              Expression.Constant(value, typeof(TValue))));
      Expression body = equals.Aggregate((accumulate, equal) =>
          Expression.Or(accumulate, equal));
      return query.Where(Expression.Lambda<Func<TEntity, bool>>(body, p));
    }
    //Optional - to allow static collection:
    public static IQueryable<TEntity> WhereIn<TEntity, TValue>
      (
        this ObjectQuery<TEntity> query,
        Expression<Func<TEntity, TValue>> selector,
        params TValue[] collection
      )
    {
      return WhereIn(query, selector, (IEnumerable<TValue>)collection);
    }
