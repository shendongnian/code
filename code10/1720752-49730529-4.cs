    class IntMinValueContractResolver : DefaultContractResolver {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            var prop = base.CreateProperty(member, memberSerialization);
            if (prop.PropertyType == typeof(int)) {
                // for int properties, set default value and ignore it when serializing
                // while populating while deserializing
                prop.DefaultValue = int.MinValue;
                prop.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            }
            return prop;
        }
    }
    JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
    {
        ContractResolver = new IntMinValueContractResolver()
    };
    // serializes to empty object {}
    var ser = JsonConvert.SerializeObject(new TestClass() { Value = int.MinValue});
