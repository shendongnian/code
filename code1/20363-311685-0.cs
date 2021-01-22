    public interface IRepository<T>
    {
        T Add(T entity);
        IQueryable<T> Fetch();
        T Update(T entity);
        void Delete(T entity);
    }
