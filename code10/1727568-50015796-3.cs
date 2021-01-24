    public class Restaurant
    {
    	public int RestaurantId { get; set; }
    	public string Name { get; set; }
    	public string Address { get; set; }
    	public string City { get; set; }
    	public virtual ICollection<Review> Reviews { get; set; }
    }
    
    public class Review
    {
    	public int ReviewId { get; set; }
    	public double Rating { get; set; }	
    	public int RestaurantId { get; set; }
    	public DateTime DateOfReview { get; set; }
    }
