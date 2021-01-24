    public class CustomStringToEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value.ToString()))
                throw new Exception("Address not provided");
    
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
