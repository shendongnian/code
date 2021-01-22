    class OrderedPropertiesContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
            {
                var props = base.CreateProperties(type, memberSerialization);
                return props.OrderBy(p => p.PropertyName).ToList();
            }
        }
    class OrderedExpandoPropertiesConverter : ExpandoObjectConverter
        {
            public override bool CanWrite
            {
                get { return true; }
            }
 
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var expando = (IDictionary<string, object>)value;
                var orderedDictionary = expando.OrderBy(x => x.Key).ToDictionary(t => t.Key, t => t.Value);
                serializer.Serialize(writer, orderedDictionary);
            }
        }
    var settings = new JsonSerializerSettings
            {
                ContractResolver = new OrderedPropertiesContractResolver(),
                Converters = { new OrderedExpandoPropertiesConverter() }
            };
 
    var serializedString = JsonConvert.SerializeObject(obj, settings);
