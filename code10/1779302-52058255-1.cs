    public class InvoiceFlattener : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value as Invoice;
            if (obj == null)
            {
                return;
            }
            writer.WriteStartArray();
            foreach (var item in obj.LineItems)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(nameof(obj.ContactName));
                writer.WriteValue(obj.ContactName);
                writer.WritePropertyName(nameof(item.Quantity));
                writer.WriteValue(item.Quantity);
                writer.WritePropertyName(nameof(item.Description));
                writer.WriteValue(item.Description);
                writer.WritePropertyName(nameof(obj.InvoiceNumber));
                writer.WriteValue(obj.InvoiceNumber);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Invoice);
        }
    }
