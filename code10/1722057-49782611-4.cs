    public class AlphaVantageApiContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            // derive the C#property name from the JSON property name
            var cSharpPropertyName = propertyName; 
            // Remove all periods from the C#property name 
            cSharpPropertyName = cSharpPropertyName.Replace(".", "");
            // replace all spaces with underscores
            cSharpPropertyName = cSharpPropertyName .Replace(" ", "_");
            // The value you return should map to the exact C# property name in your class so you need to create classes to map to.
            return cSharpPropertyName; 
        }
    }
