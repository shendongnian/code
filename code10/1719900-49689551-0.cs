	public static class Extensions
	{
		public static void IfNotNull<T>(this T instance, Action<T> action)
		{
			if (instance != null)
			{
				action(instance);
			}
		}
	}
