    public class PreferISerializableContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            if (!IgnoreSerializableInterface
                && contract is JsonObjectContract
                && typeof(ISerializable).IsAssignableFrom(objectType)
                && !objectType.GetCustomAttributes(true).OfType<JsonContainerAttribute>().Any())
            {
                contract = CreateISerializableContract(objectType);
            }
            return contract;
        }
    }
