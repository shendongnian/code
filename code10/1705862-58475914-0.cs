        public class GenericDb1Repository<T, TContext> 
        where T : class
        where TContext : DbContext, new()
    {
        internal TContext context; 
        internal DbSet<T> dbSet;
    
        public GenericRepository(TContext context) {
            this.context = context;
            this.dbSet = context.set<T>();
        }
    
        public virtual T GetByID (int id) {
            // code to return a T object by id...
        }
    
        // Other repository methods...
    }**
