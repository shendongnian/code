	public class ValueHolderJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		  serializer.Serialize(writer, ((IValueHolder)value).value);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
		  return Activator.CreateInstance(objectType, serializer.Deserialize(reader));
		}
		public override bool CanConvert(Type objectType)
		{
			return typeof(IValueHolder).IsAssignableFrom(objectType);
		}
	}
