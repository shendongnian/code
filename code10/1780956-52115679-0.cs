    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        TEntity FindById(TPrimaryKey id);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Create(IEnumerable<TEntity> entities);
    }
    internal interface IProductRepository
    {
        void SomeProductRepoMethod(int someParam);
    }
