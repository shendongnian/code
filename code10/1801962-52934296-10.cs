    public class GenericQueryRepositoryHelper<TEntity> : IQueryRepository<TEntity>
        where TEntity : class
    {
        private readonly IList<IncludeDefinition<TEntity>> _includeDefinitions;
        private readonly IGenericRepository<TEntity> _repository;
        internal GenericQueryRepositoryHelper(IGenericRepository<TEntity> repository, IncludeDefinition<TEntity> includeDefinition)
        {
            _repository = repository;
            _includeDefinitions = new List<IncludeDefinition<TEntity>> { includeDefinition };
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return _repository.Get(filter, orderBy, _includeDefinitions.ToArray());
        }
        public IQueryRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> referenceExpression)
        {
            _includeDefinitions.Add(new IncludeDefinition<TEntity, TProperty>(referenceExpression));
            return this;
        }
    }
