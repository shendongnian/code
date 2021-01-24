	public static class MyExtensions
	{
		public static bool IsBetween(this int i, int lower, int upper)
		{
			return lower < i && upper > i;
		}
	}
