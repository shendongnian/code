        private DbSet<T> _dbSet;
        public virtual IList<T> GetAll()
        {
            List<T> list;
            IQueryable<T> dbQuery = _dbSet;
            list = dbQuery
                .ToList<T>();
            return list;
        }
