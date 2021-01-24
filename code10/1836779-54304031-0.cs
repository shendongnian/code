    public class Language
    {
        public string lookup { get; set; }
        public int code { get; set; }
    }
    
    public class JSonData
    {
        public int code { get; set; }
        public int parentCode { get; set; }
        public Language language { get; set; }
        public string parentType { get; set; }
        public string text { get; set; }
    }
    ...
    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JSonData>>(dataObjectsString);
