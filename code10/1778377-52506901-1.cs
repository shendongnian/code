        public IQueryable<Defect> GetLoadQuery()
        {
            IDbSet<Defect> dbSet = DbContext.Defects;
            IQueryable<Defect> query = dbSet.AsQueryable();
            // Other code here for filtering results...
            return query;
        }
