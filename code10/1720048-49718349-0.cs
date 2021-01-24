    public class UserProduct
    {
        [Key, Column(Order = 0), ForeignKey("User")]
        public int UserId { get; set; }
        [Key, Column(Order = 1), ForeignKey("Product")]
        public int ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
