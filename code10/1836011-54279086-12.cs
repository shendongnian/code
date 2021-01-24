    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal RatingValue { get; set; }
    
        public Movie Movie { get; set; }
    }
