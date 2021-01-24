    public class DefaultReferenceHandlingCustomCreationConverter<T> : ReferenceHandlingCustomCreationConverter<T> where T : class
    {
        protected override void Populate(JObject obj, T value, JsonSerializer serializer)
        {
            using (var reader = obj.CreateReader())
                serializer.Populate(reader, value);
        }
        protected override void WriteProperties(JsonWriter writer, T value, JsonSerializer serializer, JsonObjectContract contract)
        {
            foreach (var property in contract.Properties.Where(p => p.Writable && !p.Ignored))
            {
                // TODO: handle JsonProperty attributes including
                // property.Converter, property.IsReference, property.ItemConverter, property.ItemReferenceLoopHandling, 
                // property.ItemReferenceLoopHandling, property.ObjectCreationHandling, property.ReferenceLoopHandling, property.Required                            
                var itemValue = property.ValueProvider.GetValue(value);
                writer.WritePropertyName(property.PropertyName);
                serializer.Serialize(writer, itemValue);
            }
        }
    }
