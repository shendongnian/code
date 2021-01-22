    Interface IRepository<T> where T:class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        // if you don't want to return IQueryable
        T FindById(object id);
        IEnumerable FindXXXXX(params)
        // if you prefer to return an IQueryable
        IQueryable<T> Find(Expression<Func<T, bool>> predeicate);
    }
    
