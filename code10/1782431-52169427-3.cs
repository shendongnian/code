    public class List
    {
        public Guid ListId { get; set; }
        public string OwnerId { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
    
    public class Note
    {
        public Guid ID { get; set; }
        public string OwnerId { get; set; } // You don't need OwnerId anymore because it already exists in List class. You can remove it if you want.
        [ForeignKey("List")] // Not ListId, its List
        public Guid ListId { get; set; }
        public virtual List List { get; set; }
    }
