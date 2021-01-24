    public class User
    {
        public int Id { get; set; }
        //...
        public virtual ICollection<Review> WrittenReviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Review> MyReviews { get; set; } = new HashSet<Review>();
    }
