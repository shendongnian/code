	public class Converter
	{
		private Dictionary<Type, Delegate> _factories = new Dictionary<Type, Delegate>();
	
		public void Configure<T>(Func<string, T> factory)
		{
			_factories[typeof(T)] = factory;
		}
	
		public T Convert<T>(string input)
		{
			return ((Func<string, T>)_factories[typeof(T)])(input);
		}
	}
