    public abstract class MyBaseClass<T> where T : class
	{
		public MyBaseClass(T instance)
		{
			Instance = instance;
		}
		public T Instance { get; }
	}
