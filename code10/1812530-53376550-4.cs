    public class ResourceCollectionConverter : JsonConverter<List<ResourceCollection>> {
        public override bool CanRead {
            get {
                return false; //because ReadJson is not implemented
            }
        }
        public override List<ResourceCollection> ReadJson(JsonReader reader, Type objectType, List<ResourceCollection> existingValue, bool hasExistingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, List<ResourceCollection> value, JsonSerializer serializer) {
            var obj = new JObject(); // { }
            foreach (var item in value) {
                //{ "Hello" : { "en": "Hello" } }
                obj[item.Name] = JObject.FromObject(item.Resources);
            }
            obj.WriteTo(writer);
        }
    }
 
