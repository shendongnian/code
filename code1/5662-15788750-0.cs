    // </summary>
    /// A simple clone using Json Serialization
    /// <returns>The copied object.</returns>
    public static T Clone<T>(T source)
    {
        var cereal = JsonConvert.SerializeObject(source);
        return JsonConvert.DeserializeObject<T>(cereal);
    }
