    public class FilterModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("filters")]
        public Filters Filters { get; set; }
    }
    public class Filters
    {
        [JsonProperty("filterBy")]
        public string[] FilterBy { get; set; }
        [JsonProperty("warehouseId")]
        public long[] WarehouseId { get; set; }
        [JsonProperty("orderStatus")]
        public string[] OrderStatus { get; set; }
        [JsonProperty("currencyId")]
        public long[] CurrencyId { get; set; }
    }
