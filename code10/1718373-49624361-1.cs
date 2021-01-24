    public class RootObject
    {
        public string AppId { get; set; }
        public Dictionary<string, List<ChildObject>> Merchants { get; set; }
    }
    public class ChildObject
    {
        public string ObjectId { get; set; }
        public string Type { get; set; }
        public long Ts { get; set; }
    }
