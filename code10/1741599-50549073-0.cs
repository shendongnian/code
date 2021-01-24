    public partial class Prices
    {
        // Remove this property
        // [JsonProperty("158023")]
        // public Token TokenNumber { get; set; }
    }
    public partial class Prices
    {
        public static Dictionary<string, Token> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, Token>>(json, PriceConverter.Settings);
    }
