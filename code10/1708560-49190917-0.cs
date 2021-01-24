    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullText { get; set; }
        public string Tags { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
