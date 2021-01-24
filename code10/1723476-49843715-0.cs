    public static int? GetMaxId<T>(DBSet<T> dbSet)
      where T : ICommonEntity
    {
      return dbSet.OrderByDescending(e => e.Id).FirstOrDefault();
    }
