    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(int id);
    }
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public TEntity Add(TEntity item)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
        public TEntity Get(int id)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> GetAll()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
        public bool Update(TEntity item)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
