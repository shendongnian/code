    public class Resultsets
    {
        [JsonProperty("SuggestResults")]
        [JsonConverter(typeof(SingleOrArrayJsonConverter<Suggestresult>))]
        public List<Suggestresult> SuggestResultItems { get; set; }
        public Suggestresult[] ParsedSuggestResult => SuggestResultItems.ToArray();
    }
