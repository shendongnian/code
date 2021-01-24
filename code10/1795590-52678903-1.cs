    public class Model
    {
        [JsonProperty("item")]
        public Item Item { get; set; }
    }
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("prices")]
        public List<Price> Prices { get; set; }
    }
    public class Price
    {
        [JsonProperty("priceUofM")]
        public PriceUofM PriceUofM { get; set; }
    }
    public class PriceUofM
    {
        [JsonProperty("uofm")]
        public string UofM { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
    }
