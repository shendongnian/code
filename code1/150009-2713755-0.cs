		  public abstract class Singleton<T> where T: class
		  {
		  
			private static volatile T _instance;
			
			private static object _lock = new object();
			protected Singleton()
			{
			  ConstructorInfo[] constructorPublic = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
			  if (constructorPublic.Length > 0)
			  {
				throw new Exception(String.Format("{0} has one or more public constructors so the property cannot be enforced.",
												  typeof(T).FullName));
			  }
			}
			public static T Instance
			{
			  get
			  {
				if (_instance == null)
				{
				  lock (_lock)
				  {
					if (_instance == null)
					{
					  ConstructorInfo constructorNonPublic = null;
					  try
					  {
						constructorNonPublic = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
																new Type[0], null);
					  }
					  catch (Exception e)
					  {
						throw e;
					  }
					  if (constructorNonPublic == null || constructorNonPublic.IsAssembly)
					  {
						throw new Exception(String.Format("A private or protected constructor is missing for {0}",
														  typeof (T).Name));
					  }
					  _instance = constructorNonPublic.Invoke(null) as T;
					}
				  }
				}
				return _instance;
			  }
			}
		  }
