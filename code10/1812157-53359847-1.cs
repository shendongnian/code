	public interface IRepository<T>
	{
		void Create(Entity<T> entity);
		IEnumerable<T> ReadAll();
	}
	
	public abstract class Entity<T>
	{
		protected IRepository<T> repository;
	
		public void Create()
		{
			repository.Create(this);
		}
	}
----
	public class TestEntity : Entity<TestEntity>
	{
		public override void Create()
		{
			repository.Create(this);
		}
	}
	
	public class Repository<T> : IRepository<T>
	{
		public void Create(Entity<T> entity)
		{
			throw new NotImplementedException();
		}
	
		public IEnumerable<T> ReadAll()
		{
			throw new NotImplementedException();
		}
	}
