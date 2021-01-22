`
public static class EnumHelpers
{
	/// <summary>
	/// Returns whether the given enum value is a defined value for its type.
	/// Throws if the type parameter is not an enum type.
	/// </summary>
	public static bool IsDefined<T>(T enumValue)
	{
		if (typeof(T).BaseType != typeof(System.Enum)) throw new ArgumentException($"{nameof(T)} must be an enum type.");
		return EnumValueCache<T>.DefinedValues.Contains(enumValue);
	}
	/// <summary>
	/// Statically caches each defined value for each enum type for which this class is accessed.
	/// Uses the fact that static things exist separately for each distinct type parameter.
	/// </summary>
	internal static class EnumValueCache<T>
	{
		public static HashSet<T> DefinedValues { get; }
		static EnumValueCache()
		{
			if (typeof(T).BaseType != typeof(System.Enum)) throw new Exception($"{nameof(T)} must be an enum type.");
			DefinedValues = new HashSet<T>((T[])System.Enum.GetValues(typeof(T)));
		}
	}
}
`
Note that this approach is easily extended to enum parsing as well, by using a dictionary with string keys (minding case-insensitivity and numeric string representations).
