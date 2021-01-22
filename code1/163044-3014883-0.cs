	public static class Utility
	{
		public static bool ValueChangedOrUnknown(this Dictionary<string, string> dictionary, string id, string actual)
		{
			string stored = null;
			return (!dictionary.TryGetValue(id, out actual) || stored != actual);
		}
	}
