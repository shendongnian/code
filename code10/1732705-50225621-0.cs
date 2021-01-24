	public static class ListExtensions
	{
		public static IEnumerable<TType> IsTypeOf<TType>(this IEnumerable input)
			where TType : class
		{
			foreach (object o in input)
			{
				if (o.GetType() == typeof(TType)) // take note of this, don't use is
				{
					yield return (TType)o;
				}
			}
		}
	}
