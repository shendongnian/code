    public class HealthProfessional
    {
        public ICollection<Review> HealthReviews { get; set; }
        public double CalculateAverageRating()
        {
            return HealthReviews.Average(r => r.Rating);
        }
    }
