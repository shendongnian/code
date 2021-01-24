    [JsonObject(MemberSerialization.OptIn)]
    public class customLabel:Label
    {
        [JsonProperty("X")]
        public string X { get; set; }
        [JsonProperty("Y")]
        public string Y { get; set; }
        ...
        public string H { get; set; }
        public string W { get; set; }
        public string FontName { get; set; }
        public string FontSize { get; set; }
        public string Type { get; set; }
        public string Align { get; set; }
        public string _Text { get; set; }
    }
