    public class BoolConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((bool)value) ? 1 : 0);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null || reader.Value.ToString() == "False")
			{
				return false;
			}
			return true;
		}
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(bool);
		}
	}
