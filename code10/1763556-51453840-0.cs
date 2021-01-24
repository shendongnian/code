    public class APIResult 
    {
        [JsonProperty(PropertyName = "players")]
        PlayerData PlayerData {get; set;}
    }
    public class PlayerData
    {
        [JsonProperty(PropertyName = "player")]
        List<MflPlayerJSON> Players {get; set;}
    }
    public class MflPlayerJSON
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "stats_id")]
        public string YahooID { get; set; }
        [JsonProperty(PropertyName = "draft_year")]
        public string DraftYear { get; set; }
        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("sample.json");
            var o = JsonConvert.DeserializeObject<APIResult>(json);
        }
    }
