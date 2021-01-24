    [DataContract()]
    public class Attachment
    {
        [DataMember(Name = "attach1_type")]
        [JsonProperty("attach1_type")] //Tell JsonConverter how to map your object
        public string AttachType { get; set; }//Here is property, but not variable
        [DataMember(Name = "attach1")]
        [JsonProperty("attach1_type")]
        public string Attach { get; set; }
        [DataMember(Name = "title")]
        [JsonProperty("attach1_type")]
        public string Title { get; set; }
    }
    public class SomethingJsonResult
    {
        public int ts { get; set; }
        public List<List<object>> updates { get; set; }
    }
        public void ParseJsonResult(SomethingJsonResult result)
        {
            result?.updates?.ForEach(update =>
            {
                //(Attachment)update[6] works only when your names of properties 100% match json objects
                JsonConvert.DeserializeObject<Attachment>(update[6])
                ....
            });
        }
