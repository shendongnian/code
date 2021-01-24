            public class EFRepository<T> : IRepository<T> where T : class
            {
                       public EFRepository(PayrollcshrnewEntities dbContext)
                        {
                                if (dbContext == null)
                                      throw new ArgumentNullException("dbContext");
                                DbContext = dbContext;
                                DbSet = DbContext.Set<T>();
              }
               protected ArticleEntities DbContext { get; set; }
               protected DbSet<T> DbSet { get; set; }
                    public virtual T GetById(int id)
                    {            
                           return DbSet.Find(id);
                     }
                     public virtual void Add(T entity)
                     {
                          DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                          if (dbEntityEntry.State != EntityState.Detached)
                          {
                                dbEntityEntry.State = EntityState.Added;
                           }
                           else
                          {
                                  DbSet.Add(entity);
                           }
                  }
              }
