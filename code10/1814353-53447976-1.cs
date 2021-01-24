     public class APIResponse
     {
        public string symbol { get; set; }
        public string stock_exchange_short { get; set; }
        public string timezone_name { get; set; }
        public List<IntradayLog> intraday { get; set; }
     }
    public class IntradayLog
     {
        public float open { get; set; }
        public float close { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public int volume { get; set; }
        public DateTime Date { get; set; }
     }
    var apiLogJson = JsonConvert.DeserializeObject<APIResponse>(myAPIResponse);
