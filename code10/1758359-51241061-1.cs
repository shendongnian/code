    public class Model
    {
        [JsonConverter(typeof(UTCDateTimeOffsetConverter))]
        public DateTimeOffset ExpiresOn { get; set; }
    }
