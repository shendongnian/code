    public class Article
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        // ...
        [ForeignKey("UserID")]
        public ApplicationUser CreatedBy { get; set; }
    }
