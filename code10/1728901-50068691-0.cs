    public class BankAccount
    {
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double DoubleAmount { get; set; }
    }
    public class DoubleJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(double));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return double.Parse((string)reader.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value}");
        }
    }
