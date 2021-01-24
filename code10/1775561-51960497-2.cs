    public static class DbSetExtensions
    {
       public static string EntityName<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class
       {
          return typeof(TEntity).Name;
       }
    }
