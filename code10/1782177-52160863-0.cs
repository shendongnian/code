    public partial class Welcome
    {
        [JsonProperty("Fighter Features")]
        public FighterFeatures FighterFeatures { get; set; }
    }
    public partial class FighterFeatures
    {
        [JsonProperty("Fighting Style (Archery)")]
        public FighthingStyleDefense FightingStyleArchery { get; set; }
        [JsonProperty("Second Wind")]
        public FighthingStyleDefense SecondWind { get; set; }
        [JsonProperty("Fighthing Style (Defense)")]
        public FighthingStyleDefense FighthingStyleDefense { get; set; }
    }
    public partial class FighthingStyleDefense
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("Description:")]
        public string Description { get; set; }
    }
    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
