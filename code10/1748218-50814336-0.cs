    public class AddComponentToChangeGroupParamsConverter : JsonConverter
    {
        public override bool CanWrite => true;
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var addComponentToChangeGroupParams = (AddComponentToChangeGroupParams)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Id");
            // I made Id public for simplicity you can use reflection to get value if you want
            writer.WriteValue(AddComponentToChangeGroupParams.Id); 
    
            foreach (var component in addComponentToChangeGroupParams.Component)
            {
                writer.WritePropertyName("Component");
                serializer.Serialize(writer, component);
            }
    
            writer.WriteEndObject();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
