    class MyRepository
    {
        ObjectContext context = // initialize somehow;
        public IQueryable<int> Get(Expression<Func<int, bool>> predicate)
        {
            return context.SomeObject.Where(predicate);
        }
    }
