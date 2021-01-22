    class Repository<T> where T:Class
    {
      public IQueryable<T> SearchExact(string keyword,
                                       Expression<Func<T,string>> getNameExpression)
      {
        var param = Expression.Parameter(typeof(T), "i");
        return db.GetTable<T>().Where(
                    Expression.Lambda<Func<T,bool>>(
                      Expression.Equal(
                        Expression.Invoke(
                          Expression.Constant(getNameExpression),
                          param),
                        Expression.Constant(keyword),
                      param));
      }
    }
