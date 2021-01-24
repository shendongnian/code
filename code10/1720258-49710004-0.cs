    public class Thing
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public bool IsBook { get; set; }
    }
    class NeverRequiredContractResolver : DefaultContractResolver {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            var prop = base.CreateProperty(member, memberSerialization);
            prop.Required = Required.Default;
            return prop;
        }
    }
