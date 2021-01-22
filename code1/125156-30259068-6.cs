    public static TSource MinOrDefault<TSource>(this IQueryable<TSource> source, TSource defaultValue)
    {
      return source.DefaultIfEmpty(defaultValue).Min();
    }
    
    public static TSource MinOrDefault<TSource>(this IQueryable<TSource> source)
    {
      return source.DefaultIfEmpty(defaultValue).Min();
    }
    public static TResult MinOrDefault<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector, TSource defaultValue)
    {
      return source.DefaultIfEmpty(defaultValue).Min(selector);
    }
    public static TResult MinOrDefault<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
    {
      return source.DefaultIfEmpty().Min(selector);
    }
