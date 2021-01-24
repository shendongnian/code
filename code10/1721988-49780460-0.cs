    public class Product
    {
        [Key]
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Sku { get; set; } // Should be unique
        // Other properties
    }
