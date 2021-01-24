    public abstract class EntitiesController<TEntity> where TEntity : EntityBase
    {
        public IRepository<TEntity> _repository;
        //snip
    }
