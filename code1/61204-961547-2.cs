	public static class EnumExtensions
	{
		public static bool Has<T>(this Enum source, params T[] values)
		{
			var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
			foreach (var i in values)
			{
				var mask = Convert.ToInt32(i, CultureInfo.InvariantCulture);
				if ((value & mask) == 0)
				{
					return false;
				}
			}
			return true;
		}
		public static bool Has<T>(this Enum source, T values)
		{
			var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
			var mask = Convert.ToInt32(values, CultureInfo.InvariantCulture);
			return (value & mask) != 0;
		}
		public static T Add<T>(this Enum source, T v)
		{
			var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
			var mask = Convert.ToInt32(v, CultureInfo.InvariantCulture);
			return Enum.ToObject(typeof(T), value | mask).As<T>();
		}
		public static T Remove<T>(this Enum source, T v)
		{
			var value = Convert.ToInt32(source, CultureInfo.InvariantCulture);
			var mask = Convert.ToInt32(v, CultureInfo.InvariantCulture);
			return Enum.ToObject(typeof(T), value & ~mask).As<T>();
		}
		public static T AsEnum<T>(this string value)
		{
			try
			{
				return Enum.Parse(typeof(T), value, true).As<T>();
			}
			catch
			{
				return default(T);
			}
		}
	}
