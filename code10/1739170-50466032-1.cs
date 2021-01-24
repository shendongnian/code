    [JsonConverter(typeof(DataItemConverter))]
    public class DataItem {
        public string deldate { get; set; }
        public int value { get; set; }
    }
