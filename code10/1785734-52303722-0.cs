    public class TypeConverterJsonConverter : JsonConverter
    {
        readonly TypeConverter converter;
        public TypeConverterJsonConverter(Type typeConverterType) : this((TypeConverter)Activator.CreateInstance(typeConverterType)) { }
        public TypeConverterJsonConverter(TypeConverter converter)
        {
            if (converter == null)
                throw new ArgumentNullException();
            this.converter = converter;
        }
        public override bool CanConvert(Type objectType)
        {
            return converter.CanConvertFrom(typeof(string)) && converter.CanConvertTo(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.SkipComments().TokenType;
            if (tokenType == JsonToken.Null)
                return null;
            if (!tokenType.IsPrimitive())
                throw new JsonSerializationException(string.Format("Token {0} is not primitive.", tokenType));
            var s = (string)JToken.Load(reader);
            return converter.ConvertFrom(null, CultureInfo.InvariantCulture, s);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var s = converter.ConvertToInvariantString(value);
            writer.WriteValue(s);
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader SkipComments(this JsonReader reader)
        {
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
        public static bool IsPrimitive(this JsonToken tokenType)
        {
            switch (tokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Undefined:
                case JsonToken.Null:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return true;
                default:
                    return false;
            }
        }
    }
