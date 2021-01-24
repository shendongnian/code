    public static partial class JsonExtensions
    {
        static JsonProperty GetProperty(this JsonSerializerSettings settings, Type type, string underlyingName)
        {
            // Use JsonSerializer.Create(settings) instead if your framework ignores the global JsonConvert.DefaultSettings
            var resolver = JsonSerializer.CreateDefault(settings).ContractResolver;
            var contract = resolver.ResolveContract(type) as JsonObjectContract;
            if (contract == null)
                throw new ArgumentException(string.Format("{0} is not a JSON object", type));
            return contract.Properties.Where(p => p.UnderlyingName == underlyingName).SingleOrDefault();
        }
        public static string GetPropertyName(this JsonSerializerSettings settings, Type type, string underlyingName)
        {
            var property = settings.GetProperty(type, underlyingName);
            // The property might be null if it is nonpublic and not marked with [JsonProperty]
            return property == null ? null : property.PropertyName;
        }
        public static bool GetIsIgnored(this JsonSerializerSettings settings, Type type, string underlyingName)
        {
            var property = settings.GetProperty(type, underlyingName);
            // The property might be null if it is nonpublic and not marked with [JsonProperty]
            return property == null ? true : property.Ignored;
        }
    }
