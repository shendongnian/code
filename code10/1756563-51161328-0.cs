    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = File.ReadAllText("D://readjson.txt");
                var obj = JsonConvert.DeserializeObject<List<RootObject>>(data);
            }
        }
    
        public class RootObject
        {
            public string user_id { get; set; }
            public string username { get; set; }
            public string count300 { get; set; }
            public string count100 { get; set; }
            public string count50 { get; set; }
            public string playcount { get; set; }
            public string ranked_score { get; set; }
            public string total_score { get; set; }
            public string pp_rank { get; set; }
            public string level { get; set; }
            public string pp_raw { get; set; }
            public string accuracy { get; set; }
            public string count_rank_ss { get; set; }
            public string count_rank_ssh { get; set; }
            public string count_rank_s { get; set; }
            public string count_rank_sh { get; set; }
            public string count_rank_a { get; set; }
            public string country { get; set; }
            public string pp_country_rank { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<object> events { get; set; }
        }
    
    }
