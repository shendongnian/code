    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
       protected readonly YourDbContext _context;
       public Repository(YourDbContext DbContextScope)  //Intitalizing DBContext
       {
         if(DbContextScope == null)
         {
            throw new ArgumentNullException("DbContextScope");
         }
         _context = DbContextScope.Create();
       }
     public TEntity FindSingleEager(Expression<Func<TEntity, bool>> predicate, List<string> paths)
     {
         var query = _context.Set<TEntity>().Where(predicate);
         foreach (string path in paths)
         {
           query = query.Include(path);
         }
         return query.SingleOrDefault<TEntity>();
      }
    }
