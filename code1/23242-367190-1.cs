	public static class Resolver // : IResolver
	{
		private static IResolver _current;
		public static object Resolve(Type type)
		{
			return Current.Resolve(type);
		}
		public static object Resolve(string name)
		{
			return Current.Resolve(name);
		}
		public static T Resolve<T>() where T : class
		{
			return Current.Resolve<T>();
		}
		public static T Resolve<T>(string name) where T : class
		{
			return Current.Resolve<T>(name);
		}
		private static IResolver Current
		{
			get
			{
				if (_current == null)
				{
					_current = new SpringResolver();
				}
				return _current;
			}
		}
	}
