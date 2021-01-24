    [JsonConverter(typeof(DateToString))]
	public struct Date
	{
		private DateTime _date;
		public Date(DateTime date)
		{
			_date = date;
		}
		public static implicit operator Date(DateTime date) => new Date(date);
		public override string ToString() => _date.ToString("yyyy-MM-dd");
	}
	
	public class DateToString : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Date);
		public override bool CanRead => false;
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			=> throw new NotImplementedException();
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
			writer.WriteValue(value.ToString());
	}
