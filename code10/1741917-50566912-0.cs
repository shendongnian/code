    public class Home
    {
        [JsonProperty("firstName")]
        public int Id { get; set; } // value: 2
        //public Dictionary<string,string> dictionary { get; set; }
        [JsonProperty("propertyName")]
        public string propertyName { get; set; } // value: administration
        [JsonIgnore]
        public string Text { get; set; } // value: text1
    }
