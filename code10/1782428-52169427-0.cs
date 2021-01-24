    public class List
    {
        public Guid ListId { get; set; }
        public string OwnerId { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
    
    public class Note
    {
        public Guid ID { get; set; }
        public string OwnerId { get; set; }
        [ForeignKey("ListId")]
        public Guid ListId { get; set; }
        public virtual List List { get; set; }
    }
