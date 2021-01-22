    public static class ObjectExtensions
	{
		public static bool? TryParse(this object value, out bool? parsed)
		{
			parsed = null;
			try
			{
				if (value == null)
					return true;
				bool parsedValue;
				parsed = bool.TryParse(value.ToString(), out parsedValue) ? (bool?)parsedValue : null;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
