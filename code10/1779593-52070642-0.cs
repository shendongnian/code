    class Program
        {
            static void Main(string[] args)
            {
                var json1 = "{  \"Test\": [ { \"Cust-no\": \"00000001\", \"Cust-status\": \"555\", \"Last-update\": \"1999-08-17\" } ]}";
                var json2 = "{  \"Test\": [ { \"Cust-no\": \"00000001\", \"Cust-status\": \"666\", \"Last-update\": \"2018-08-17\" } ]}";
                var list1 = JsonConvert.DeserializeObject<RootObject>(json1);
                var list2 = JsonConvert.DeserializeObject<RootObject>(json2);
                
            }
        }
    
        public class Test
        {
            [JsonProperty("Cust-no")]
            public string CustomerNumber { get; set; }
    
            [JsonProperty("Cust-status")]
            public string Status { get; set; }
    
            [JsonProperty("Last-update")]
            public string LastUpdated { get; set; }
        }
    
        public class RootObject
        {
            public List<Test> Test { get; set; }
        }
