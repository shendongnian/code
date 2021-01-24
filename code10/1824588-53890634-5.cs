    public class Hits
    {
      [JsonProperty("total")]
      public int Total { get; set; }
      [JsonProperty("max_score")]
      public int MaxScore { get; set; }
      [JsonProperty("hits")]
      public List<Hit> Hits { get; set; }
    }
