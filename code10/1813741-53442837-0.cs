    public class Customer
    {
        public Customer()
        {
            Reviews = new HashSet<Review>();
        }
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
