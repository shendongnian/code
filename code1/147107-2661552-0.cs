    public class Product
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    
        [Required]
        [Range(1,50)]
        public int PriceInCents { get; set; }
    
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
