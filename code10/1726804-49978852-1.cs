    public class ChildAttribute
    {
        public int? sequence { get; set; }
        public List<ChildAttribute> children { get; set; }
        public string value { get; set; }
        public int? parentId { get; set; }
    }
