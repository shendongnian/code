    namespace DatabaseProject.Models
    {
        public class Review
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public int ProductId { get; set; }
            public string Text { get; set; }
            public int Stars { get; set; }
            [Required]
            [ForeignKey("ProductId")]
            public Product Product { get; set; }
            [Required]
            [ForeignKey("CustomerId")]
            public Customer Customer { get; set; }
        }
    }
