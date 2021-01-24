    public class ConstructorConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(value.GetType()) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("Type {0} does not correspond to a JSON object.", value.GetType()));
            // Possibly check whether JsonObjectAttribute is applied, and use JsonObjectAttribute.Title if present.
            writer.WriteStartConstructor(value.GetType().Name);
            foreach (var provider in contract.GetConstructorParameterValueProviders())
            {
                serializer.Serialize(writer, provider.GetValue(value));
            }
            writer.WriteEndConstructor();
        }
    }
    public static partial class JsonExtensions
    {
        internal static IEnumerable<IValueProvider> GetConstructorParameterValueProviders(this JsonObjectContract contract)
        {
            return contract.CreatorParameters.Select(p => contract.GetConstructorParameterValueProvider(p)).ToArray();
        }
        internal static IValueProvider GetConstructorParameterValueProvider(this JsonObjectContract contract, JsonProperty parameter)
        {
            if (parameter.ValueProvider != null)
                return parameter.ValueProvider;
            var property = contract.Properties.GetClosestMatchProperty(parameter.PropertyName);
            var provider = property == null ? null : property.ValueProvider;
            if (provider == null)
                throw new JsonSerializationException(string.Format("Cannot get IValueProvider for {0}", parameter));
            return provider;
        }
    }
