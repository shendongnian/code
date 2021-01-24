	public class CountryConverter : JsonConverter
	{
		public override bool CanRead { get { return true; } }
		public override bool CanWrite { get { return false; } }
		public override bool CanConvert(Type objectType)
		{
			return typeof(Country) == objectType;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var code = obj.GetValue("code", StringComparison.OrdinalIgnoreCase)?.Value<string>();
			if (code != null)
			{
				return Countries.All.FirstOrDefault(c => string.Equals(c.Code, code, StringComparison.OrdinalIgnoreCase));
			}
			return null;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
