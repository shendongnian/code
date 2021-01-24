    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class Welcome
    {
        [JsonProperty("LocalObservationDateTime")]
        public DateTimeOffset LocalObservationDateTime { get; set; }
        [JsonProperty("EpochTime")]
        public long EpochTime { get; set; }
        [JsonProperty("WeatherText")]
        public string WeatherText { get; set; }
        [JsonProperty("WeatherIcon")]
        public long WeatherIcon { get; set; }
        [JsonProperty("IsDayTime")]
        public bool IsDayTime { get; set; }
        [JsonProperty("Temperature")]
        public Temperature Temperature { get; set; }
        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }
        [JsonProperty("Link")]
        public string Link { get; set; }
    }
    public partial class Temperature
    {
        [JsonProperty("Metric")]
        public Imperial Metric { get; set; }
        [JsonProperty("Imperial")]
        public Imperial Imperial { get; set; }
    }
    public partial class Imperial
    {
        [JsonProperty("Value")]
        public double Value { get; set; }
        [JsonProperty("Unit")]
        public string Unit { get; set; }
        [JsonProperty("UnitType")]
        public long UnitType { get; set; }
    }
    public partial class Welcome
    {
        public static Welcome[] FromJson(string json) => JsonConvert.DeserializeObject<Welcome[]>(json, QuickType.Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this Welcome[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
        };
    }
