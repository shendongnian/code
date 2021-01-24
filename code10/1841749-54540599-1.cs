    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InputObjectDTO
    {
        public string FullName { get; set; }
        public decimal TotalPrice { get; set; }
    }
