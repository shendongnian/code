    public class CurrencyDTO
    {
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public string From { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public List<QuoteCurrencyDTO> To { get; set; }
    }
    public class QuoteCurrencyDTO
    {
        public string QuoteCurrency { get; set; }
        public double Mid { get; set; }
    }
