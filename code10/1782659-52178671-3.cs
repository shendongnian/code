    public class MyClassName
    {
        [JsonConverter(typeof(JsonExponentialConverter))]
        public decimal Amount { get; set; }
    }
