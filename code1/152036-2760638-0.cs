    public interface IRepository<TEntity, TID> where TEntity : IEntity<TID>
    {
        void Add(TEntity entity);
    
        void Delete(TEntity entity);
    }
    public interface IProductRepository : IRepository<Product, int>
