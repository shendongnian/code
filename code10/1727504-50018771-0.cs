    [Table("orders")]
    class Order
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        // rest omitted for clarity
    }
    [Table("products")]
    class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // rest omitted for clarity
    }
