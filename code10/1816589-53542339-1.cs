    public class StringToComplexConverter<TObject> : JsonConverter<TObject>
    {
        public override bool CanWrite => false;
        public override TObject ReadJson(
            JsonReader reader,
            Type objectType,
            TObject existingValue,
            bool hasExistingValue,
            JsonSerializer serializer
            )
        {
            if (reader.TokenType == JsonToken.String)
            {
                var ctor = objectType.GetConstructor(new[] { typeof(string) });
                return (TObject)ctor.Invoke(new[] { (string)reader.Value });
            }
            else
            {
                var result = (TObject)Activator.CreateInstance(objectType);
                serializer.Populate(reader, result);
                return result;
            }
        }
        public override void WriteJson(JsonWriter writer, TObject value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
