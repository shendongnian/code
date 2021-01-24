    public class PartEntity
    {
        public string PartNumber { get; set; }
        public PartEntityInformation PartEntityInformation { get; set; }
    }
    public class PartEntityInformation
    {
        public string Position { get; set; }
        public string Name { get; set; }
        public List<PartEntity> ReplacedBy { get; set; }
    }
