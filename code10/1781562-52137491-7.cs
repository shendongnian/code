    [JsonConverter(typeof(AbsBaseConverter))]
    public abstract class absBase {
        public int A { get; set; }
        public string B { get; set; }
        public abstract string Generate();
    }
