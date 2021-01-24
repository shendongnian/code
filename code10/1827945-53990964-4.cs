    public class Rate
    {
        public string name { get; set; }
        public decimal rate { get; set; }
    }
    public class RootObject
    {
        public Dictionary<string, Rate> rates { get; set; }
        public string time { get; set; }
    }
