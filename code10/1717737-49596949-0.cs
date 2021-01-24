    public class Post
    {
        public int Id { get; set; }
        // This is User Id from AspNetUsers
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string PostContent { get; set; }
    }
