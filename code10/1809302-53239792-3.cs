    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
    productService.AddReview(1,
        new Review
        {
            CustomerId = 1,
            ProductId = XXX,
            Stars = 2,
            Text = "It's a good camera",
        })
