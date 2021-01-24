     public class SomeClass
     {
        [JsonProperty(PropertyName = "some_element")]
        public string SomeProperty { get; set; }
    
        [JsonProperty(PropertyName = "should_be_dic_element")]
        public List<Dictionary<string, string>> Dictionary { get; set; }
     }
