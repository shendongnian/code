	public static class Extensions
	{
		public static bool EqualsAll<T>(this T subject, params T[] values) =>
            values == null || values.Length == 0 || values.All(v => v.Equals(subject));
	}
