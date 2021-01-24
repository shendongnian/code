    /// <summary>
    /// Any unmapped properties from the JSON data deserializes into this property.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JToken> UnmappedData { get; set; }
