    public static Object GetPropValue(String name, object obj, Type type)
		{
			var parts = name.Split('.').ToList();
			var currentPart = parts[0];
			PropertyInfo info = type.GetProperty(currentPart);
			if (info == null) { return null; }
			if (name.IndexOf(".") > -1)
			{
				parts.Remove(currentPart);
				return GetPropValue(String.Join(".", parts), info.GetValue(obj, null), info.PropertyType);
			} else
			{
				return info.GetValue(obj, null).ToString();
			}
		}
