    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class demo
    {
        [JsonProperty(PropertyName = "a1")]
        public int? a1 { get; set; }
        [JsonProperty(PropertyName = "a2")]
        public int? a2 { get; set; }
        [JsonProperty(PropertyName = "a3")]
        public int? a3 { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<JToken> data { get; set; }
    }
    var json = @"{
              ""a1"": 10,
              ""a2"": 11,
              ""a3"": 13,
              ""uuid"": ""1c18f0c8-02d0-425a-8dc7-13dc6d0b46af"",
              ""data"": [
                {
                  ""id"": 1,
                  ""timeStamp"": ""2018-01-03T08:01:00Z"",
                  ""quantity"": 200.0,
                  ""tag"": ""/sometag/""
                },
                {
                  ""id"": 2,
                  ""timeStamp"": ""2018-01-03T08:05:00Z"",
                  ""quantity"": 100.0,
                  ""tag"": ""/someothertag/""
                },
                {
                ""id"": 3,
                  ""name"": ""somename"",
                  ""age"": 32
                }
              ]
            }";
    var demo1 = JsonConvert.DeserializeObject<demo>(json);
    // Let's get the timeStamp of item 2.
    var timeStamp = demo1.data[1].SelectToken("timeStamp").ToObject<DateTime>();
    // Let's get the age of item 3.
    var age = demo1.data[2].SelectToken("age").ToObject<int>();
