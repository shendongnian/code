    public class BConverter : JsonConverter<B>
    {
        public override void WriteJson(JsonWriter writer, B value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override B ReadJson(JsonReader reader, Type objectType, B existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = reader.Value as string;
            return new B() { Field2 = s };
        }
    }
