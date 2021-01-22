	struct DATABASE
	{
		public enum enums { NOTCONNECTED, CONNECTED, ERROR }
		static List<string> strings =
			new List<string>() { "Not Connected", "Connected", "Error" };
		public string GetString(DATABASE.enums value)
		{
			return strings[(int)value];
		}
	}
