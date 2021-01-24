    public abstract class BaseRepository<TEntity, TPrimaryKey> : 
        IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        public abstract TEntity FindById(TPrimaryKey id);
        public abstract void Create(TEntity entity);
        public abstract void Delete(TEntity entity);
        public void Create(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Create(entity);
            }
        }
    }
