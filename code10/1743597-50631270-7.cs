    [JsonConverter(typeof(DateParseHandlingConverter), DateParseHandling.None)]
    public class RootObject
    {
        [JsonProperty("revisedDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(FixedIsoDateTimeOffsetConverter))]
        public DateTimeOffset? RevisedDate { get; set; }
    }
