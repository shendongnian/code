ObjectModel
        public partial class ObjectModel
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
