    public class Article
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<Review> Reviews { get; set; }
    }
    public class Review
    {
        public int Points { get; set; }
    }
