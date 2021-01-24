    namespace DatabaseProject.Models
    {
        public class Review
        {
            public int Id { get; set; }
            [Required]
            public int CustomerId { get; set; }
            [Required]
            public int ProductId { get; set; }
            public string Text { get; set; }
            public int Stars { get; set; }
            [ForeignKey("ProductId")]
            public Product Product { get; set; }
            [ForeignKey("CustomerId")]
            public Customer Customer { get; set; }
        }
    }
