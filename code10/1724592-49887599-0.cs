	// This class caches all value names for an enum the first time it is accessed
	internal static class EnumNameCache<T> where T : struct, IComparable, IFormattable, IConvertible
	{
		private static Dictionary<T, string> sNameMap;
		static EnumNameCache()
		{
			sNameMap = new Dictionary<T, string>();
			Type type = typeof(T);
			foreach (T value in Enum.GetValues(type).Cast<T>())
			{
				string valueName = value.ToString();
				sNameMap.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<DisplayAttribute>()?.Name ?? valueName);
			}
		}
		public static string GetName(T value)
		{
			return sNameMap[value];
		}
	}
	// Contains extension methods for enums
	internal static class EnumExtensions
	{
		public static string GetDisplayName<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		{
			return EnumNameCache<T>.GetName(value);
		}
	}
	// Example display attribute with a Name property because System.ComponentModel.DisplayNameAttribute cannot be used on enum values
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	internal class DisplayAttribute : Attribute
	{
		public string Name { get; }
		public DisplayAttribute(string name)
		{
			Name = name;
		}
	}
