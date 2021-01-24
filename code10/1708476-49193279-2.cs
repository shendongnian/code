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
        // Implement all the methods of the interface 
    }
