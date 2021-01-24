    public class Repository<TEntity> : DbQueryProxy<TEntity> where TEntity : class
    {
    	private readonly DbSet<TEntity> _DbSet;
    
    	internal Repository(DbSet<TEntity> dbSet) : base(dbSet)
    	{
    		_DbSet = dbSet;
    	}
    
    	private Repository()
    	{
    	}
    
    	public static implicit operator DbSet<TEntity>(Repository<TEntity> entry) => entry._DbSet;
    
    	public static implicit operator Repository<TEntity>(DbSet<TEntity> entry) => new Repository<TEntity>(entry);
    
    	#region DbSet<TEntity>
    
    	public TEntity Add(TEntity entity) => _DbSet.Add(entity);
    
    	public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities) => _DbSet.AddRange(entities);
    
    	public TEntity Attach(TEntity entity) => _DbSet.Attach(entity);
    
    	public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity => _DbSet.Create<TDerivedEntity>();
    
    	public override bool Equals(object obj) => _DbSet.Equals(obj);
    
    	public override int GetHashCode() => _DbSet.GetHashCode();
    
    	public TEntity Find(params object[] keyValues) => _DbSet.Find(keyValues);
    
    	public Task<TEntity> FindAsync(params object[] keyValues) => _DbSet.FindAsync(keyValues);
    
    	public Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues) => _DbSet.FindAsync(cancellationToken, keyValues);
    
    	public TEntity Remove(TEntity entity) => _DbSet.Remove(entity);
    
    	public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities) => _DbSet.RemoveRange(entities);
    
    	#endregion DbSet<TEntity>
    }
