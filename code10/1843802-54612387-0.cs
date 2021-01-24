    public class UserBook
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
