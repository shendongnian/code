        public class Results
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool hasVariables { get; set; }
            public List<string> children { get; set; }
            public string levels { get; set; }
        }
    
        public class Links
        {
            public string first { get; set; }
            public string self { get; set; }
            public string next { get; set; }
            public string last { get; set; }
        }
    
        public class JsonObject
        {
            public int totalRecords { get; set; }
            public int page { get; set; }
            public int pageSize { get; set; }
            public Links links { get; set; }
            public List<Results> results { get; set; }
        }
