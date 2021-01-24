    using Newtonsoft.Json;
    ...
    [JsonObject(MemberSerialization.OptIn)]
    public class Class1
    {
        [JsonProperty]
        public string Property1 { set; get; }
        public string Property2 { set; get; }
    }
