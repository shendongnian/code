    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [NotMapped]
        public string ParentName { get; set; }
    }
