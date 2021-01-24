    public class ResourceCollectionConverter : JsonConverter<ResourceCollection> {
        public override ResourceCollection ReadJson(JsonReader reader, Type objectType, ResourceCollection existingValue, bool hasExistingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, ResourceCollection value, JsonSerializer serializer) {
            var obj = new JObject();
            obj[value.Name] = JObject.FromObject(value.Resources);
            obj.WriteTo(writer);
        }
    }
 
