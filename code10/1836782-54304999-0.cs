        public class Language
    {
        public string lookup { get; set; }
        public int code { get; set; }
    }
    public class JSonData
    {
         [Newtonsoft.Json.JsonProperty("code")]
        public string code { get; set; }
         [Newtonsoft.Json.JsonProperty("parentCode")]
         public int parentCode { get; set; }
         [Newtonsoft.Json.JsonProperty("language")]
        public Language language { get; set; }
         [Newtonsoft.Json.JsonProperty("parentType")]
        public string parentType { get; set; }
         [Newtonsoft.Json.JsonProperty("text")]
        public string text { get; set; }
    }
    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JSonData>>(dataObjectsString);
    var filtereddata = data.Where(s => s.language.code.Equals(2));
