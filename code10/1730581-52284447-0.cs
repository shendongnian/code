       public abstract class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IDataContext
        {
            public DataContext(DbContextOptions options)
            : base(options)
            {
            }
        
            // reduced for brevity
        
            public T Get<T>(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null) where T : class, IEntity
            {
                IQueryable<T> queryable = this.Set<T>();
        
                if (includes != null)
        		{
        			queryable = includes(queryable);
        		}
        
                return queryable.FirstOrDefault(x => x.Id == id);
            }
        }
        
       context.Get<Job>(id, includes: source => source.Include(x => x.Equipment).ThenInclude(x => x.Type));
