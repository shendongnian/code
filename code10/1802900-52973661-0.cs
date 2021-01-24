    public interface IApplicationDbContext {
        IDbSet<ApplicationUser> Users { get; set; }
    
        int SaveChanges();
    
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
