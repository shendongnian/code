    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Sku { get; set; }
        // Other properties
    }
