    public class CustomJsonConverter : JsonConverter
    {
        ...
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // somehow using serializer passed to this method doesn't seem to work
            var token = JToken.FromObject(value, new JsonSerializer()
            {
                ContractResolver = new DontIgnoreContractResolver()
            });
            token.WriteTo(writer);
        }
    }
    public class DontIgnoreContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            if (jsonProperty.Ignored)
            {
                jsonProperty.Ignored = false;
            }
            return jsonProperty;
        }
    }
