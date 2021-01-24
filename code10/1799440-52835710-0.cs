            public partial class ObjectTypes
            {
                [JsonProperty("data")]
                public Data Data { get; set; }
            }
        
            public partial class Data
            {
                [JsonProperty("objects")]
                public Dictionary<string, Object> Objects { get; set; }
            }
        
            public partial class Object
            {
                [JsonProperty("Id")]
                public string Id { get; set; }
        
                [JsonProperty("Name")]
                public string Name { get; set; }
            }
