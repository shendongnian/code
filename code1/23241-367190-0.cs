	public interface IResolver
	{
		object Resolve(Type type);
		object Resolve(string name);
		T Resolve<T>() where T : class;
		T Resolve<T>(string name) where T : class;
	}
