        public IQueryable<T> Get<T>(
            Expression<Func<T,bool>> predicate
            ) where T : class
        {
            IQueryable<T> query = (IQueryable<T>)GetTable(typeof(T));
            if (predicate != null) query = query.Where(predicate);
            return query;
        }
