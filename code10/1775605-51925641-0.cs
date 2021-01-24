	public interface IBaseRepository<R>
	{
		Task<T> Add<T>(R value, string typeName);
	}
	
	public class Test<R> : IBaseRepository<R>
	{
		public Task<T> Add<T>(R value, string typeName)
		{
			throw new NotImplementedException();
		}
	}
