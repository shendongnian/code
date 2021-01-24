    private T GetLatestEntry(T entity)
    {
      if (context.Set<T>.Any())
      {
        var max = context.Set<T>.Max(x => x.UpdatedAt);
         return context.Set<T>.Where(x => x.UpdatedAt == max).FirstOrDefault();
      }
       return null;
     }
