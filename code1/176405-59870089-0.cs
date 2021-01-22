 lang-c#
private class SortedPropertiesContractResolver : DefaultContractResolver
{
    // use a static instance for optimal performance
    static SortedPropertiesContractResolver instance;
    
    static SortedPropertiesContractResolver() { instance = new SortedPropertiesContractResolver(); }
    public static SortedPropertiesContractResolver Instance { get { return instance; } }
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        var properties = base.CreateProperties(type, memberSerialization);
        if (properties != null)
            return properties.OrderBy(p => p.UnderlyingName).ToList();
        return properties;
    }
}
Implement:
 lang-c#
var settings = new JsonSerializerSettings { ContractResolver = SortedPropertiesContractResolver.Instance };
var json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
