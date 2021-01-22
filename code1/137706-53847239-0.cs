    public class LowercaseJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };
    
        public static void Serialize(TextWriter file, object o)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                ContractResolver = new LowercaseContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            serializer.Serialize(file, o);
        }
    
        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
            }
        }
    }
