    public interface IEntity
    {
    	int Id { get; }
    }
    
    public partial class News : IEntity
    {
    }
    
    public class Repository<T> where T : class, IEntity
    {
    
    	private readonly DataContext _db;
    
    	public Repository(DataContext db)
    	{
    		_db = db;
    	}
    
    	public T Get(int id)
    	{
    		Expression<Func<T, bool>> hasId = HasId(id);
    		return _db.GetTable<T>().Single(hasId);
    	}
    
    	// entity => entity.Id == id;   
    	private Expression<Func<T, bool>> HasId(int id)
    	{
    		ParameterExpression entityParameter = Expression.Parameter(typeof (T), "entity");
    		return Expression.Lambda<Func<T, bool>>(
    			Expression.Equal(
    				Expression.Property(entityParameter, "Id"),
    				Expression.Constant(id)
    				),
    			new[] {entityParameter}
    			);
    	}
    }
