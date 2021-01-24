    public class PartModel
    {
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public string Position { get; set; }
        public List<PartModel> ReplacedBy { get; set; }
    }
