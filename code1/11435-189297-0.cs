	public static class ObjectUtility
	{
		public static string ToDebug(this object obj)
		{
			if (obj == null)
				return "<null>";
			var type = obj.GetType();
			var props = type.GetProperties();
			var sb = new StringBuilder(props.Length * 20 + type.Name.Length);
			sb.Append(type.Name);
			sb.Append("\r\n");
			foreach (var property in props)
			{
				if (!property.CanRead)
					continue;
				// AppendFormat defeats the point
				sb.Append(property.Name);
				sb.Append(": ");
				sb.Append(property.GetValue(obj, null));
				sb.Append("\r\n");
			}
			return sb.ToString();
		}
	}
