	public class DestinationConverter : JsonConverter
	{
        public override bool CanConvert(System.Type objectType)
        {
			return objectType == typeof(Destination);
        }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
			var id = serializer.Deserialize<int?>(reader);
			if (id == null)
				return null;
			return new Destination(id.Value);
        }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
			// WriteJson() is never called with a null value, instead Json.NET writes null automatically.
			writer.WriteValue(((Destination)value).Id);
        }
	}
