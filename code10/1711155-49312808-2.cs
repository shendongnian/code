    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(BroadcastCoverage), "channel")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(InternetCoverage), "url")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(ThirdCoverage), "differentProperty")]
    public class CoverageBase
    {
        public string path { get; set; }
        public string name { get; set; }
    }
    public class BroadcastCoverage : CoverageBase
    {
        public string channel { get; set; }
        public string callSign { get; set; }
    }
    public class InternetCoverage : CoverageBase
    {
        public string url { get; set; }
    }
    public class ThirdCoverage : CoverageBase
    {
        public string differentProperty { get; set; }
    }
    public class Request
    {
        public string path { get; set; }
        public List<CoverageBase> coverages { get; set; }
    }
