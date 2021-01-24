    public class HealthProfessional
    {
        public ICollection<Review> HealthReviews { get; set; }
        public double CalculateAverageRating()
        {
            return HealthReviews.Where(r => r.Id).Average(r => r.Rating);
        }
    }
