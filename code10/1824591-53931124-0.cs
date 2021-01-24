    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "{  \"took\":31,  \"timed_out\":false,  \"_shards\": {    \"total\":91,    \"successful\":91,    \"skipped\":0,    \"failed\":0  },  \"hits\":{    \"total\":1,    \"max_score\":1.0,    \"hits\":[      {        \"_index\":\"my-index\",        \"_type\":\"doc\",        \"_id\":\"TrxrZGYQRaDom5XaZp23\",        \"_score\":1.0,        \"_source\":{          \"my_id\":\"65a107ed-7325-342d-adab-21fec0a97858\",          \"host\":\"something\",          \"zip\":\"12345\"        }      },    ]  }}";
                RootObject t = JsonConvert.DeserializeObject<RootObject>(json);
            }
    
            public class Shards
            {
                public int total { get; set; }
                public int successful { get; set; }
                public int skipped { get; set; }
                public int failed { get; set; }
            }
    
            public class Source
            {
                public string my_id { get; set; }
                public string host { get; set; }
                public string zip { get; set; }
            }
    
            public class Hit
            {
                public string _index { get; set; }
                public string _type { get; set; }
                public string _id { get; set; }
                public double _score { get; set; }
                public Source _source { get; set; }
            }
    
            public class Hits
            {
                public int total { get; set; }
                public double max_score { get; set; }
                public List<Hit> hits { get; set; }
            }
    
            public class RootObject
            {
                public int took { get; set; }
                public bool timed_out { get; set; }
                public Shards _shards { get; set; }
                public Hits hits { get; set; }
            }
        }
    }
