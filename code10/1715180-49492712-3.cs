    interface IChangeableSet<T> : IQueryable<T> : where T: IId
    {
        public T Get(int id)
        public T Add(T item);
        public T Remove(int Id);
        public T Remove(T item);
    }
    class DbSet<T> : IChangeableSet<T> : where T: IId
    {
        public DbSet(System.Data.Entity.IDbset<T> dbSet)
        {
            this.dbset = dbSet
        }
        private readonly System.Data.Entity.IDbSet<T> dbSet;
        public T Get(int id)
        {
            return this.DbSet.Where(item => item.Id == id).SingleOrDefault();
            // here is where I uses that all items implement IId
        }
        public T Add(T item)
        {
             return this.dbSet.Add(item);
        }
        ... // TODO: fill the other functions
    }
