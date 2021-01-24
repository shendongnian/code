    public class RequiredPropertiesContractResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            foreach (var contractProperty in contract.Properties)
            {
                if (contractProperty.PropertyType.IsValueType
                    && contractProperty.AttributeProvider.GetAttributes(typeof(RequiredAttribute), inherit: true).Any())
                {
                    contractProperty.Required = Required.Always;
                }
            }
            return contract;
        }
    }
