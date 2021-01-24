    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SerializePropertyNamesAsCamelCase]
    public class SearchResult
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("abstract")]
        public string[] Abstract { get; set; }
        [JsonProperty("dateIssued")]
        public DateTime? DateIssued { get; set; }
        [JsonProperty("@search.score")]
        public decimal Score { get; set; }
        [JsonProperty("@search.highlights")]
        public Highlights Highlights { get; set; }
    }
