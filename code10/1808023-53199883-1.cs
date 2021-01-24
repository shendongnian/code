    [JsonConverter(typeof(ItemsPayloadConverter))]
    public class ItemsPayload
    {
        public List<Dictionary<string, string>> Wrapper { get; set; }
    }
