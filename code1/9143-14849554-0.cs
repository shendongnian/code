	public static class ComparisonExtensions
	{
		public static Comparison<T> WithGetHashCode<T>(this Comparison<T> current)
		{
			return (x, y) =>
			{
				var result = current(x, y);
				if (result == 0)
					return x.GetHashCode() - y.GetHashCode();
				return result;
			};
		}
	}
