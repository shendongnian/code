	public static class ExtensionMethods
	{
		static public KeyValuePair<string,string> GetPair(this NameValueCollection source, string key)
		{
			return new KeyValuePair<string, string>
			(
				key,
				source.Get(key)
			);
		}
	}
