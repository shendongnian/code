    public class Blog
    {
        public int BlogId { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Url { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Rating { get; set; }
    }
