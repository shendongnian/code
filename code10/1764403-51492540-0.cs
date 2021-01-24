    public class ExchangeRate
        {
            public string Error { get; set; }
            public bool Success { get; set; }
            public Ticker Ticker { get; set; }
            public int Timestamp { get; set; }
        }
    
    public class Ticker
        {
            public string @Base { get; set; }
            public string Change { get; set; }
            public string Price { get; set; }
            public string Target { get; set; }
            public string Volume { get; set; }
        }
