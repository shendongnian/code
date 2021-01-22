    List<T> myList = new List<T>();
    ...
    public IQueryable<int> Get(Expression<Func<int, bool>> criteria)
    {
        return myList.Where(criteria.Compile()).AsQueryable();
    }
