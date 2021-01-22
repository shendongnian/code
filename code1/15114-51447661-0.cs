    	public static string ReplaceCaseInsensitive(this string str, string oldValue, string newValue)
		{
			if (str == null) throw new ArgumentNullException(nameof(str));
			if (oldValue == null) throw new ArgumentNullException(nameof(oldValue));
			if (oldValue.Length == 0) throw new ArgumentException("String cannot be of zero length.", nameof(oldValue));
			var position = str.IndexOf(oldValue, 0, StringComparison.OrdinalIgnoreCase);
			if (position == -1) return str;
			var sb = new StringBuilder(str.Length);
			var lastPosition = 0;
			do
			{
				sb.Append(str, lastPosition, position - lastPosition);
				sb.Append(newValue);
			} while ((position = str.IndexOf(oldValue, lastPosition = position + oldValue.Length, StringComparison.OrdinalIgnoreCase)) != -1);
			sb.Append(str, lastPosition, str.Length - lastPosition);
			return sb.ToString();
		}
