    public abstract class Singleton<T> where T : class
	{
		/// <summary>
		/// Returns the singleton instance.
		/// </summary>
		public static T Instance
		{
			get
			{
				return SingletonAllocator.instance;
			}
		}
		internal static class SingletonAllocator
		{
			internal static T instance;
			static SingletonAllocator()
			{
				CreateInstance(typeof(T));
			}
			public static T CreateInstance(Type type)
			{
				ConstructorInfo[] ctorsPublic = type.GetConstructors(
					BindingFlags.Instance | BindingFlags.Public);
				if (ctorsPublic.Length > 0)
					throw new Exception(
						type.FullName + " has one or more public constructors so the property cannot be enforced.");
				ConstructorInfo ctorNonPublic = type.GetConstructor(
					BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], new ParameterModifier[0]);
				if (ctorNonPublic == null)
				{
					throw new Exception(
						type.FullName + " doesn't have a private/protected constructor so the property cannot be enforced.");
				}
				try
				{
					return instance = (T)ctorNonPublic.Invoke(new object[0]);
				}
				catch (Exception e)
				{
					throw new Exception(
						"The Singleton couldnt be constructed, check if " + type.FullName + " has a default constructor", e);
				}
			}
		}
	}
