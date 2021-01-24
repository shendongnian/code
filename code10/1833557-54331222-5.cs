    public class VersionConverter : JsonConverter<Version>
    {
        public override void WriteJson(JsonWriter writer, Version value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    
        public override Version ReadJson(JsonReader reader, Type objectType, Version existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
    
            return new Version(s);
        }
    }
    
    public class NuGetPackage
    {
        public string PackageId { get; set; }
        public Version Version { get; set; }
    }
