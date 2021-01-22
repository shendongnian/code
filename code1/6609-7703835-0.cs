	public class Singleton<T> where T : class
	{
		class SingletonCreator
		{
			static SingletonCreator() { }
			internal static readonly T Instance =
				typeof(T).InvokeMember(typeof(T).Name,
										BindingFlags.CreateInstance |
										BindingFlags.Instance |
										BindingFlags.Public |
										BindingFlags.NonPublic,
										null, null, null) as T;
		}
		public static T Instance
		{
			get { return SingletonCreator.Instance; }
		}
	}
