    public abstract class BaseController<TEntity, TRepository, TIdType>
        where TEntity : class, new()
        where TRepository : IBaseRepository<TEntity, TIdType>
    {
        protected TRepository Repository = RepositiryFactory.GetRepository<TEntity, TRepository>();
        public IList<TEntity> GetAll()
        {
            return Repository.GetAll().ToList();
        }
        public IList<TEntity> GetAll(string sortExpression)
        {
            return Repository.GetAll(sortExpression).ToList();
        }
        public int GetCount()
        {
            return Repository.GetAll().Count();
        }
        public IList<TEntity> GetAll(int startRowIndex, int maximumRows)
        {
            var results = Repository.GetAll().Skip(startRowIndex).Take(maximumRows);
            return results.ToList();
        }
        public IList<TEntity> GetAll(string sortExpression, int startRowIndex, int maximumRows)
        {
            var results = Repository.GetAll(sortExpression).Skip(startRowIndex).Take(maximumRows);
            return results.ToList();
        }
    }
