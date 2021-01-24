        public class DateTimeConverter : JsonConverter<DateTime>
        {
            public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
            {
                writer.WriteValue(value.ToString("u"));
            }
            public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                string s = (string)reader.Value;
                return DateTime.ParseExact(s,"u", CultureInfo.InvariantCulture);
            }
        }
