    public class GlobalQuote
    {
       [JsonProperty("Global Quote")]
       public Stock Stock { get; set; } 
    }
    public class Stock
    {
       [JsonProperty("01. symbol")]
       public string symbol { get; set; }
       [JsonProperty("02. latest trading day")]
       public string latesttradingday { get; set; }
       [JsonProperty("03. previous close")]
       public string previousclose { get; set; } 
    }
    private static async Task Main(string[] args)
    {
       string test = @"{
                 ""Global Quote"": {
                 ""01. symbol"": ""MSFT"",
                 ""02. latest trading day"": ""2018-11-19"",
                 ""03. previous close"": ""108.2900""}
             }";
    
       var result = JsonConvert.DeserializeObject<GlobalQuote>(test);
    
    }
