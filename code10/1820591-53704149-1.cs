    class Sample
    {
        [JsonExtensionData]
        public Dictionary<string, JToken> Data { get; set; }
    }
    public class Userr
    {
        public String id { get; set; }
        public String imageURL { get; set; }
        public String search { get; set; }
        public String status { get; set; }
        public String username { get; set; }
    }
