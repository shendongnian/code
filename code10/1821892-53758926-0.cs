    public class AmountConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Amount);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Would decimal be more appropriate than double?
            var value = serializer.Deserialize<double?>(reader);
            if (value == null)
                return null;
            return new Amount(value.Value);
            
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((Amount)value).Value);
        }
    }
