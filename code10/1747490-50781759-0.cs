	public class AbstractEntityConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(AbstractEntity);
		}
		public override object ReadJson(JsonReader reader,
			Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject item = JObject.Load(reader);
			var type = item["TYPE"].Value<string>();
			switch (type)
			{
				case "TABLE1":
					return item.ToObject<TABLE1>();
				case "TABLE2":
					return item.ToObject<TABLE2>();
				default:
					return null;
			}
		}
		public override void WriteJson(JsonWriter writer,
			object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
