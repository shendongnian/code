    public static class DbSetExtensions
    {
       public static DbSqlQuery<TEntity> SqlQuery<TEntity>(this DbSet<TEntity> dbSet, string sql, params object[] parameters) where TEntity : class
       {
          // Do stuff with dbSet...
          Logger.Instance.Write(string.Replace("Entity \"{0}\" executed the command...", typeof(TEntity).Name));
       }
    }
    
