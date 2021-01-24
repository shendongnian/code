    public class Countries
    {
        [JsonProperty(PropertyName = "TotalCount")]
        string TotalCount { get; set; }
        [JsonProperty(PropertyName = "Country")]
        public List<Ctry> Country { get; set; }
    }
    public class Ctry
    {
        [JsonProperty(PropertyName = "CountryId")]
        string CountryId { get; set; }
        [JsonProperty(PropertyName = "CountryName")]
        string CountryName { get; set; }
    }
