    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private DbContextBase Context
        {
            get
            {
                return _unitOfWork.UoWContext;
            }
        }
        private DbSet<TEntity> DbSet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }
    }
