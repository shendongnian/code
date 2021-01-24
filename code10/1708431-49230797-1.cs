    class DbRepo<Tentity, Tid> where Tentity : class
    {
        public Func<IQueryable<Tentity>> DefaultGetAll {get; set;}
        public TEntity Single(Tid id)
        {
            return this.Single(id, this.DefaultGetAll);
        }
        public Tentity Single(Tid id, Func<IQueryable<Tentity>> getAll)
        {
            return getAll()
               .Where(item => item.Id == id)
               .Single();
        }
        public IReadonlyList<Tentity> Where(Expression<Func<TEntity, bool>> predicate)
        {
             return this.Where(predicate, this.DefaultGetall);
        }
        public IReadonlyList<Tentity> Where(Expression<Func<TEntity, bool>> predicate,
             Func<IQueryable<Tentity>> getAll)
        {
             return getAll().Where(predicate).ToList();
        }
    }
