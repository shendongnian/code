	public interface IRepository<T>
	{
	    void Create(Entity<T> entity);
	    IEnumerable<T> ReadAll();
	}
	
	public abstract class Entity<T>
	{
		public T Value;
	    protected IRepository<T> repository;
	
	    public void Create()
	    {
	        repository.Create(this);
	    }
	}
	
	public class TestEntity : Entity<TestEntity>
	{
	}
	
	public class Repository<T> : IRepository<T>
	{
	    List<T> list = new List<T>();
	    public void Create(Entity<T> entity)
	    {
	        list.Add(entity.Value);
	    }
	
	    public IEnumerable<T> ReadAll()
	    {
	        return list;
	    }
	}
