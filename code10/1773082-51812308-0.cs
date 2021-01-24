        public class Rootobject
        {
            public Value value { get; set; }
        }
        public class Value
        {
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public string interval { get; set; }
            public Segment[] segments { get; set; }
        }
        public class Segment
        {
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public Segment1[] segments { get; set; }
        }
        public class Segment1
        {
	       [JsonProperty("requests/count")]
	       public RequestsCount requestscount { get; set; }
	       [JsonProperty("request/name")]
	       public string requestname { get; set; }
        }
        public class RequestsCount
        {
            public int sum { get; set; }
        }
