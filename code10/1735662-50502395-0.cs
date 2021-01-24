    public partial interface IRepository<T> where T : BaseEntity
    {
       
        T GetById(object id);
       
        void Insert(T entity);
      
        void Insert(IEnumerable<T> entities);
    
        void Update(T entity);
      
        void Update(IEnumerable<T> entities);
       
        void Delete(T entity);
      
        void Delete(IEnumerable<T> entities);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
    public interface IDbContext
    {
       
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
       
        int SaveChanges();
      
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new();
    
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
       
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
      
        void Detach(object entity);
       
        bool ProxyCreationEnabled { get; set; }
      
        bool AutoDetectChangesEnabled { get; set; }
