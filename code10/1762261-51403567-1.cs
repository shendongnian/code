    [JsonConverter(typeof(RowConverter))]
    public class Row
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
