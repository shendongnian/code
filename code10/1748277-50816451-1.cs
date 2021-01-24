    public class ExportModel
    {
        [JsonProperty(PropertyName = "ids")]
        public string[] Ids {get;set;}
        [JsonProperty(PropertyName = "options")]
        public Options Options {get;set;}
    }
