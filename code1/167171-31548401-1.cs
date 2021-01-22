        public static string encodeString(string value)
	{
		return HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
	}
	public static string decodeString(string value)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(value)));
	}
