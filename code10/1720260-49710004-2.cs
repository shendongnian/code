    class CustomPropertyContractResolver : DefaultContractResolver {
        private readonly Action<MemberInfo, JsonProperty> _propFixup;
        public CustomPropertyContractResolver(Action<MemberInfo, JsonProperty> propFixup) {
            _propFixup = propFixup;
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            var prop = base.CreateProperty(member, memberSerialization);
            _propFixup?.Invoke(member , prop);
            return prop;
        }
    }
    JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
    {
        ContractResolver = new CustomPropertyContractResolver((member, prop) => {
            if (member.DeclaringType == typeof(Thing) && member.Name == "IsBook") {
                prop.Required = Required.Default;
            }
        })
    };
    var test = JsonConvert.DeserializeObject<Thing>("{\"Name\":\"some name\"}");
