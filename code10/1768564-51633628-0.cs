    public class MyModel
    {
        public MyModel()
        {
        }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("date")]
        public double Date { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("systemDate")]
        public double SomeDate { get; set; }
    }
