    void Main()
    {
        string test = @"{
        ""Meta Data"": {
            ""1. Information"": ""Intraday (15min) open, high, low, close prices and volume"",
            ""2. Symbol"": ""MSFT"",
            ""3. Last Refreshed"": ""2018-09-28 15:45:00"",
            ""4. Interval"": ""15min"",
            ""5. Output Size"": ""Full size"",
            ""6. Time Zone"": ""US/Eastern""
        },
        ""Time Series (15min)"": {
            ""2018-09-28 15:45:00"": {
                ""1. open"": ""114.2800"",
                ""2. high"": ""114.5600"",
                ""3. low"": ""114.2400"",
                ""4. close"": ""114.4800"",
                ""5. volume"": ""2316251""
            },
            ""2018-09-28 15:30:00"": {
                ""1. open"": ""114.4450"",
                ""2. high"": ""114.4500"",
                ""3. low"": ""114.2600"",
                ""4. close"": ""114.2900"",
                ""5. volume"": ""759991""
            },
            ""2018-09-28 15:15:00"": {
                ""1. open"": ""114.3550"",
                ""2. high"": ""114.5200"",
                ""3. low"": ""114.3100"",
                ""4. close"": ""114.4400"",
                ""5. volume"": ""515174""
            }
        }
    }";
    
        JsonConvert.DeserializeObject<Result>(test).Dump();
    
    }
    
    // Define other methods and classes here
    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }
    
        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }
    
        [JsonProperty("3. Last Refreshed")]
        public string LastRefreshed { get; set; }
    
        [JsonProperty("4. Interval")]
        public string Interval { get; set; }
    
        [JsonProperty("5. Output Size")]
        public string OutputSize { get; set; }
    
        [JsonProperty("6. Time Zone")]
        public string TimeZone { get; set; }
    }
    
    public class CandleStick
    {
    
        [JsonProperty("1. open")]
        public string Open { get; set; }
    
        [JsonProperty("2. high")]
        public string High { get; set; }
    
        [JsonProperty("3. low")]
        public string Low { get; set; }
    
        [JsonProperty("4. close")]
        public string Close { get; set; }
    
        [JsonProperty("5. volume")]
        public string Volume { get; set; }
    }
    
    
        public class Result
    {
    
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }
    
        [JsonProperty("Time Series (15min)")]
        public Dictionary<DateTime, CandleStick> TimeSeries15min { get; set; }
    }
