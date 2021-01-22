		public static T DeepCopy<T>(this T value)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			string json = js.Serialize(value);
			return js.Deserialize<T>(json);
		}
