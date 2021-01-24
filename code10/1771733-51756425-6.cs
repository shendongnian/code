    public class ErrorMessageConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(ErrorMessage);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // handle the primitive string
            if (reader.TokenType == JsonToken.String)
                return new ErrorMessage { Message = (string)reader.Value };
            // handle a complex object; just assume that it is an `ErrorMessage` here
            else if (reader.TokenType == JsonToken.StartObject)
                return JObject.Load(reader).ToObject<ErrorMessage>();
            throw new NotSupportedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
