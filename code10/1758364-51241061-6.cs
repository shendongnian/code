    public class Model
    {
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset ExpiresOn { get; set; }
    }
