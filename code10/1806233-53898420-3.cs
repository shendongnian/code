    public abstract class MultiTenantServices<TEntity, TId>
        where TEntity : class, IMultiTenantEntity<TId>
        where TId : IComparable
    {
        private readonly IMultiTenantRepository<TEntity, TId> _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiTenantServices{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected MultiTenantServices(IMultiTenantRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }
