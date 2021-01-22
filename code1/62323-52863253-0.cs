		public static class Tool
		{
				public static object CastTo<T>(object value) where T : class
				{
					return value as T;
				}
				private static readonly MethodInfo CastToInfo = typeof (Tool).GetMethod("CastTo");
				public static object DynamicCast(object source, Type targetType)
				{
					return CastToInfo.MakeGenericMethod(new[] { targetType }).Invoke(null, new[] { source });
				}
		}
