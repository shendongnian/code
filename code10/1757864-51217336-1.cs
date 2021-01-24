    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("descricao")]
        public string Descricao { get; set; }
        [JsonProperty("observacao")]
        public string Observacao { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class Data
    {
        [JsonProperty("item")]
        public List<Item> Items { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
    public class Response
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("result")]
        public bool Result { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Data Items { get; set; }
    }
