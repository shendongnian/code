    public class Markets
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Volume_24h { get; set; }
        public string Timestamp { get; set; }
    }
    dynamic obj = JsonConvert.DeserializeObject<Markets>(json);
