	/// <summary>
	/// Helper methods to reduce code needed in constructing JSON items
	/// </summary>
	public static class JsonHelper
	{		
		public static KeyValuePair<string, JsonValue> CreateProperty(string name, string value)
		{
			return new KeyValuePair<string, JsonValue>(name, new JsonPrimitive(value));
		}
		public static KeyValuePair<string, JsonValue> CreateProperty(string name, int value)
		{
			return new KeyValuePair<string, JsonValue>(name, new JsonPrimitive(value));
		}
		// Replicate above for each constructor of JsonPrimitive
		public static KeyValuePair<string, JsonValue> CreateProperty(string name, JsonValue value)
		{
			return new KeyValuePair<string, JsonValue>(name, value);
		}
	}
