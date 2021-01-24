    public class RootObject
    {
        [JsonProperty("collection", Required = Required.Always)]
        public List<Item> Collection { get; set; }
        public RootObject()
        {
            Collection = new List<Item>();
        }
    }
    public class Item
    {
        [JsonProperty("timePeriod", Required = Required.Always)]
        public TimePeriod TimePeriod { get; set; }
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }
        [JsonProperty("amount", Required = Required.Always)]
        public int Amount { get; set; }
        [JsonProperty("outstanding", Required = Required.Always)]
        public int Outstanding { get; set; }
        [DataType(DataType.Date)]
        [JsonProperty("due", Required = Required.Always)]
        public DateTime Due { get; set; }
    }
    public class TimePeriod
    {
        [DataType(DataType.Date)]
        [JsonProperty("from", Required = Required.Always)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        [JsonProperty("to", Required = Required.Always)]
        public DateTime To { get; set; }
    }
