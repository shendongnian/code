    [Table("paid_authors")]
    public class PaidAuthor
    {
        [Key]
        [Column("paid_author_id")]
        public string PaidAuthorId { get; set; }
    
        [Column("name")]
        public string Name { get; set; }
    
        public virtual List<HardbackBook> HardbackBooks { get; } = new HashSet<HardbackBook>();
    }
    
    [Table("hardback_books")]
    public class HardbackBook
    {
        [Key]
        [Column("hardback_book_id")]
        public Guid HardbackBookId { get; set; }
    
        [Column("title")]
        public string Title { get; set; }
    
        public PaidAuthor PaidAuthor { get; set; }
    
        [ForeignKey("PaidAuthor")] 
        [Column("paid_author_id")]
        public string PaidAuthorId { get; set; }
    }
