    public class AlphaVantageApiContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName
                .Replace(".", "")
                .Replace(" ", "_");
        }
    }
