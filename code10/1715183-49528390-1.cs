    public class DataStore : IDisposable
    {
    	private readonly DbContext _dbContext;
    
    	#region constructors
    
    	public DataStore()
    	{
    		_dbContext = new DbContext();
    	}
    
    	#endregion constructors
    
    	internal DbContext Context => _dbContext;
    
    	public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase => _dbContext.RemoveRange(entities);
    
    	#region db sets
    
    	public Repository<Teacher> Teachers => _dbContext.Teachers; // implicit type conversion from DbSet<TEntity> to Repository<TEntity>!
    	public Repository<Student> Students => _dbContext.Students;
    	public Repository<Grade> Grades => _dbContext.Grade;
    
    	#endregion db sets
    
    	#region DbContext
    
    	public void Dispose() => _dbContext.Dispose();
    
    	public int SaveChanges() => _dbContext.SaveChanges();
    
    	public Repository<TEntity> Set<TEntity>() where TEntity : EntityBase => _dbContext.Set<TEntity>();
    
    	public override bool Equals(object obj) => _dbContext.Equals(obj);
    
    	public override int GetHashCode() => _dbContext.GetHashCode();
    
    	public override string ToString() => _dbContext.ToString();
    
    	#endregion DbContext
    }
