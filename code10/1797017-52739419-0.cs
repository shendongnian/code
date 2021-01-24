    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        } 
    
        // Implements CreateOrUpdate in one function watching the State of an entity
        public void AddOrUpdate(T entity)
        {
            var entry = this.RepositoryContext.Entry(entity);
            switch (entry.State)
            {
                case EntityState.Detached:
                    this.RepositoryContext.Set<T>().Add(entity);
                    break;
                case EntityState.Modified:
                    this.RepositoryContext.Set<T>().Update(entity);
                    break;
                case EntityState.Added:
                    this.RepositoryContext.Set<T>().Add(entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything  
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
