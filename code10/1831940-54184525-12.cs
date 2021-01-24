    public class NestedJsonPathConverter : JsonConverter {
        public override object ReadJson(JsonReader reader, Type objectType,
                                        object existingValue, JsonSerializer serializer) {
            JObject jo = JObject.Load(reader);
            var properties = jo.Properties();
            object targetObj = existingValue ?? Activator.CreateInstance(objectType);
            var resolver = serializer.ContractResolver as DefaultContractResolver;
            foreach (PropertyInfo propertyInfo in objectType.GetProperties()
                                                    .Where(p => p.CanRead && p.CanWrite)) {
                var attributes = propertyInfo.GetCustomAttributes(true).ToArray();
                if (attributes.OfType<JsonIgnoreAttribute>().Any())
                    continue;
                var jsonProperty = attributes.OfType<JsonPropertyAttribute>().FirstOrDefault();
                var jsonPath = (jsonProperty != null ? jsonProperty.PropertyName : propertyInfo.Name);
                if (resolver != null) {
                    jsonPath = resolver.GetResolvedPropertyName(jsonPath);
                }
                JToken token = GetTokenCaseInsensitive(properties, jsonPath);
                if (token != null && token.Type != JTokenType.Null) {
                    object value = token.ToObject(propertyInfo.PropertyType, serializer);
                    propertyInfo.SetValue(targetObj, value, null);
                }
            }
            return targetObj;
        }
        JToken GetTokenCaseInsensitive(IEnumerable<JProperty> properties, string jsonPath) {
            JToken token = null;
            var parts = jsonPath.Split('.');
            var property = properties.FirstOrDefault(p =>
                string.Equals(p.Name, parts[0], StringComparison.OrdinalIgnoreCase)
            );
            for (var i = 1; i < parts.Length && property != null && property.Value is JObject; i++) {
                var jo = property.Value as JObject;
                property = jo.Properties().FirstOrDefault(p =>
                    string.Equals(p.Name, parts[i], StringComparison.OrdinalIgnoreCase)
                );
            }
            if (property != null && property.Type != JTokenType.Null) {
                token = property.Value;
            }
            return token;
        }
        public override bool CanConvert(Type objectType) {
            //Check of any JsonPropertyAttribute has nested property name
            return objectType
                .GetProperties()
                .Any(p =>
                    p.CanRead
                    && p.CanWrite
                    && p.GetCustomAttributes(true)
                        .OfType<JsonPropertyAttribute>()
                        .Count(jp => (jp.PropertyName ?? p.Name).Contains('.')) > 0);
        }
        public override bool CanWrite {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
    
