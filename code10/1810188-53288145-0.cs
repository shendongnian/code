    public class EsiObjConverter<T> : JsonConverter
    {
        const string EsiObjName = "EsiObj";
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(value.GetType()) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("Non-object type {0}", value));
            writer.WriteStartObject();
            int propertyCount = 0;
            bool lastWasEsiProperty = false;
            foreach (var property in contract.Properties.Where(p => p.Readable && !p.Ignored))
            {
                if (property.UnderlyingName == EsiObjName && property.PropertyType == typeof(string))
                {
                    var esiValue = (string)property.ValueProvider.GetValue(value);
                    if (!string.IsNullOrEmpty(esiValue))
                    {
                        if (propertyCount > 0)
                        {
                            WriteValueDelimiter(writer);
                        }
                        writer.WriteWhitespace("\n");
                        writer.WriteRaw(esiValue);
                        // If it makes replacement easier, you could force the ESI string to be on its own line by calling
                        // writer.WriteWhitespace("\n");
                        propertyCount++;
                        lastWasEsiProperty = true;
                    }
                }
                else
                {
                    var propertyValue = property.ValueProvider.GetValue(value);
                    // Here you might check NullValueHandling, ShouldSerialize(), ...
                    if (propertyCount == 1 && lastWasEsiProperty)
                    {
                        WriteValueDelimiter(writer);
                    }
                    writer.WritePropertyName(property.PropertyName);
                    serializer.Serialize(writer, propertyValue);
                    propertyCount++;
                    lastWasEsiProperty = false;
                }
            }
            writer.WriteEndObject();
        }
        static void WriteValueDelimiter(JsonWriter writer)
        {
            var args = new object[0];
            // protected virtual void WriteValueDelimiter() 
            // https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonWriter_WriteValueDelimiter.htm
            // Since this is overridable by client code it is unlikely to be removed.
            writer.GetType().GetMethod("WriteValueDelimiter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(writer, args);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override bool CanRead { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
