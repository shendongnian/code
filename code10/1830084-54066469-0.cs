    public class UserContext : DbContext
    {
        public DbSet<UsersDo> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersDo>()
                .HasKey(e => e.UsersId);
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Repo<T> where T : class
    {
        private readonly DbSet<T> dbSet;
        public Repo(DbContext context)
        {
            dbSet = context.Set<T>();
        }
        public T Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            // If you use the First() method you will get an exception when the result is empty.
            return query?.FirstOrDefault();
        }
    }
