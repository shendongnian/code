    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    public class OrderEntity
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
