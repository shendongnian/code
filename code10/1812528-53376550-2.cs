    public class ResourceCollectionConverter : JsonConverter<ResourceCollection> {
        public override bool CanRead {
            get {
                return false; //because ReadJson is not implemented
            }
        }
        public override ResourceCollection ReadJson(JsonReader reader, Type objectType, ResourceCollection existingValue, bool hasExistingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, ResourceCollection value, JsonSerializer serializer) {
            var obj = new JObject(); // { }
            //{ "Hello" : { "en": "Hello" } }
            obj[value.Name] = JObject.FromObject(value.Resources);
            obj.WriteTo(writer);
        }
    }
 
