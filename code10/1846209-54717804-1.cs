    public class RangeOrValueConverter : JsonConverter
    {
        class RangeDTO
        {
            public int Min, Max;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RangeOrValue) || Nullable.GetUnderlyingType(objectType) == typeof(RangeOrValue);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var range = (RangeOrValue)value;
            if (range.IsRange)
            {
                var dto = new RangeDTO { Min = range.Min, Max = range.Max };
                serializer.Serialize(writer, dto);
            }
            else
            {
                writer.WriteValue(range.Value);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.MoveToContent().TokenType)
            {
                case JsonToken.Null:
                    // nullable RangeOrValue; return null.
                    return null;
                case JsonToken.Integer:
                    return new RangeOrValue(reader.ValueAsInt32());
                default:
                    var dto = serializer.Deserialize<RangeDTO>(reader);
                    return new RangeOrValue(dto.Min, dto.Max);
            }
        }
    }
