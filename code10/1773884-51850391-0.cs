    public class EmbeddedLiteralConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            using (new PushValue<bool>(true, () => Disabled, (canWrite) => Disabled = canWrite))
            {
                using (var sw = new StringWriter(writer.Culture))
                {
                    // Copy relevant settings
                    using (var nestedWriter = new JsonTextWriter(sw) 
                    { 
                        DateFormatHandling = writer.DateFormatHandling,
                        DateFormatString = writer.DateFormatString,
                        DateTimeZoneHandling = writer.DateTimeZoneHandling,
                        StringEscapeHandling = writer.StringEscapeHandling,
                        FloatFormatHandling = writer.FloatFormatHandling,
                        Culture = writer.Culture,
						// Remove if you don't want the escaped \r\n characters in the embedded JSON literal:
                        Formatting = writer.Formatting, 
                    })
                    {
                        serializer.Serialize(nestedWriter, value);
                    }
                    writer.WriteValue(sw.ToString());
                }
            }
        }
        [ThreadStatic]
        static bool disabled;
        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }
        public override bool CanWrite { get { return !Disabled; } }
        public override bool CanRead { get { return !Disabled; } }
		
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var contract = serializer.ContractResolver.ResolveContract(objectType);
            if (contract is JsonPrimitiveContract)
                throw new JsonSerializationException("Invalid type: " + objectType);
            if (existingValue == null)
                existingValue = contract.DefaultCreator();
            if (reader.TokenType == JsonToken.String)
            {
                var json = (string)JToken.Load(reader);
                using (var subReader = new JsonTextReader(new StringReader(json)))
                {
                    // By populating a pre-allocated instance we avoid an infinite recursion in EmbeddedLiteralConverter<T>.ReadJson()
                    // Re-use the existing serializer to preserve settings.
                    serializer.Populate(subReader, existingValue);
                }
            }
            else
            {
                serializer.Populate(reader, existingValue);
            }
            return existingValue;
        }
    }
    struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        #region IDisposable Members
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
        #endregion
    }
