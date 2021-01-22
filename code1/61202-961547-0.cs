	public static class ObjectExtension
	{
		public static T As<T>(this object value)
		{
			return (value != null && value is T) ? (T)value : default(T);
		}
		public static int AsInt(this string value)
		{
			if (value.HasValue())
			{
				int result;
				var success = int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
				if (success)
				{
					return result;
				}
			}
			return 0;
		}
		public static Guid AsGuid(this string value)
		{
			return value.HasValue() ? new Guid(value) : Guid.Empty;
		}
	}
